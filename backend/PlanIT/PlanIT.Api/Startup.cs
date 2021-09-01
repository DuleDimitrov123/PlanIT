using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlanIT.Repository;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Repository.Repositories.Implementations;
using PlanIT.Service;
using PlanIT.Service.BusinessLogic;
using PlanIT.Service.Services.Contracts;
using PlanIT.Service.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanIT.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStaffCanCreateByCompanyRepository, StaffCanCreateByCompanyRepository>();
            services.AddScoped<IStaffByCompanyRepository, StaffByCompanyRepository>();

            services.AddScoped<ICheckWorkingFromOffice, CovidCheckWorkingFromOffice>();
            services.AddScoped<ITypeOfWorkByStaffAndDateRepository, TypeOfWorkByStaffAndDateRepository>();
            services.AddScoped<ITypeOfWorkByCompanyRepository, TypeOfWorkByCompanyRepository>();
            services.AddScoped<IBreakfastByCompanyRepository, BreakfastByCompanyRepository>();
            services.AddScoped<ITypeOfWorkService, TypeOfWorkService>();
            //services.AddTransient<ICompanyService, CompanyService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            ConfigureAuthentication(services);
            ConfigureAuthorization(services);

            services.AddScoped<IMeetingRoomByCompanyRepository, MeetingRoomByCompanyRepository>();
            services.AddScoped<IReservedMeetingRoomRepository, ReservedMeetingRoomRepository>();
            services.AddScoped<IAllowedNumberInMeetingRoom, CovidAllowedNumberInMeetingRoom>();
            services.AddScoped<IMeetingRoomService, MeetingRoomService>();

            services.AddScoped<IAvailableBreakfastByCompanyRepository, AvailableBreakfastByCompanyRepository>();
            services.AddScoped<IBreakfastByStaffRepository, BreakfastByStaffRepository>();
            services.AddScoped<IBreakfastService, BreakfastService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlanIT.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlanIT.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = Configuration["Jwt:Audience"],
                ValidIssuer = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = tokenValidationParameters;
            });
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("NormalStaff", policy => policy.RequireClaim("Staff", "NormalStaff"));

                //StaffCanCreate can access everything that NormalStaff can, but also some creational things ("StaffCanCreate")
                cfg.AddPolicy("StaffCanCreate", policy => policy.RequireClaim("Staff", "StaffCanCreate"));
            });
        }
    }
}
