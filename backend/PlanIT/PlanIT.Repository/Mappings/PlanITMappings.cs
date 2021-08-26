using Cassandra;
using PlanIT.DataAccess;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using System;
using System.Collections.Generic;

namespace PlanIT.Repository.Mappings
{
    public class PlanITMappings : Cassandra.Mapping.Mappings
    {
        public PlanITMappings()
        {
            For<Company>()
                .TableName(DatabaseNames.Company).CaseSensitive()
                .PartitionKey(c => c.CompanyName)
                .Column(c => c.CompanyName, cm => cm.WithName(CompanyColumns.CompanyName)).CaseSensitive()
                .Column(c => c.Country, cm => cm.WithName(CompanyColumns.Country).WithDbType<string>()).CaseSensitive()
                .Column(c => c.City, cm => cm.WithName(CompanyColumns.City).WithDbType<string>()).CaseSensitive()
                .Column(c => c.Address, cm => cm.WithName(CompanyColumns.Address).WithDbType<string>()).CaseSensitive()
                .Column(c => c.Description, cm => cm.WithName(CompanyColumns.Description).WithDbType<string>()).CaseSensitive();

            For<Staff>()
                .TableName(DatabaseNames.Staff).CaseSensitive()
                .PartitionKey(s => s.Username)
                .Column(s => s.Username, cm => cm.WithName(StaffColumns.Username).WithDbType<string>()).CaseSensitive()
                .Column(s => s.Password, cm => cm.WithName(StaffColumns.Password).WithDbType<string>()).CaseSensitive()
                .Column(s => s.FirstName, cm => cm.WithName(StaffColumns.FirstName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.LastName, cm => cm.WithName(StaffColumns.LastName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.DateOfBirth, cm => cm.WithName(StaffColumns.DateOfBirth).WithDbType<LocalDate>()).CaseSensitive()
                .Column(s => s.CompanyName, cm => cm.WithName(StaffColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.Position, cm => cm.WithName(StaffColumns.Position).WithDbType<string>()).CaseSensitive()
                .Column(s => s.CanCreate, cm => cm.WithName(StaffColumns.CanCreate).WithDbType<bool>()).CaseSensitive();

            For<StaffCanCreateByCompany>()
                .TableName(DatabaseNames.StaffCanCreateByCompany).CaseSensitive()
                .PartitionKey(s => s.CompanyName)
                .Column(s => s.CompanyName, cm => cm.WithName(StaffCanCreateByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.StaffUsernames, cm => cm.WithName(StaffCanCreateByCompanyColumns.StaffUsernames).WithDbType<List<string>>()).CaseSensitive();

            For<StaffByCompany>()
                .TableName(DatabaseNames.StaffByCompany).CaseSensitive()
                .PartitionKey(s => s.CompanyName)
                .ClusteringKey(s => s.StaffUsername)
                .Column(s => s.CompanyName, cm => cm.WithName(StaffByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.StaffUsername, cm => cm.WithName(StaffByCompanyColumns.StaffUsername).WithDbType<string>()).CaseSensitive()
                .Column(s => s.Position, cm => cm.WithName(StaffByCompanyColumns.Position).WithDbType<string>()).CaseSensitive();
        }
    }
}
