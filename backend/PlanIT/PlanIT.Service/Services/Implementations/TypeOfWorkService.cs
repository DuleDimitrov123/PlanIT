using Cassandra;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Helpers;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.BusinessLogic;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Helpers;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Implementations
{
    public class TypeOfWorkService : ITypeOfWorkService
    {
        private readonly ITypeOfWorkByStaffAndDateRepository _typeOfWorkByStaffAndDateRepository;
        private readonly ITypeOfWorkByCompanyRepository _typeOfWorkByCompanyRepository;
        private readonly ICheckWorkingFromOffice _checkWorkingFromOffice;

        private readonly ICompanyService _companyService;
        private readonly IStaffService _staffService;

        public TypeOfWorkService(ITypeOfWorkByStaffAndDateRepository typeOfWorkByStaffAndDateRepository,
            ITypeOfWorkByCompanyRepository typeOfWorkByCompanyRepository,
            ICheckWorkingFromOffice checkWorkingFromOffice,
            ICompanyService companyService,
            IStaffService staffService)
        {
            _typeOfWorkByStaffAndDateRepository = typeOfWorkByStaffAndDateRepository;
            _typeOfWorkByCompanyRepository = typeOfWorkByCompanyRepository;
            _checkWorkingFromOffice = checkWorkingFromOffice;
            _companyService = companyService;
            _staffService = staffService;
        }

        public IList<TypeOfWorkBO> GetAllTypeOfWorkByStaffAndDate()
        {
            IList<TypeOfWorkByStaffAndDate> typeOfWorkByStaffAndDates = _typeOfWorkByStaffAndDateRepository.GetAllTypeOfWorkByStaffAndDate();
            IList<TypeOfWorkBO> typeOfWorkBOs = new List<TypeOfWorkBO>();

            foreach (var type in typeOfWorkByStaffAndDates)
            {
                typeOfWorkBOs.Add(TypeOfWorkHelpers.MakeTypeOfWorkBOFromTypeOfWorkByStaffAndDate(type));
            }

            return typeOfWorkBOs;
        }

        public IList<TypeOfWorkBO> GetStaffTypeOfWorkHistory(string staffUsername)
        {
            IList<TypeOfWorkByStaffAndDate> typeOfWorkByStaffAndDates = _typeOfWorkByStaffAndDateRepository.GetStaffTypeOfWorkHistory(staffUsername);
            IList<TypeOfWorkBO> typeOfWorkBOs = new List<TypeOfWorkBO>();

            foreach (var type in typeOfWorkByStaffAndDates)
            {
                typeOfWorkBOs.Add(TypeOfWorkHelpers.MakeTypeOfWorkBOFromTypeOfWorkByStaffAndDate(type));
            }

            return typeOfWorkBOs;
        }

        public string GetTypeOfWorkByStaffAndDate(string staffUsername, DateTime date)
        {
            return _typeOfWorkByStaffAndDateRepository.
                GetTypeOfWorkByStaffAndDate(
                staffUsername,
                new LocalDate(date.Year, date.Month, date.Day));
        }

        public void AddTypeOfWorkByStaffAndDate(string staffUsername, DateTime date, string typeOfWork)
        {
            _typeOfWorkByStaffAndDateRepository.AddTypeOfWorkByStaffAndDate(
                TypeOfWorkHelpers.MakeTypeOfWorkByStaffAndDateFromTypeOfWorkBO(
                    new TypeOfWorkBO
                    {
                        StaffUsername = staffUsername,
                        Date = new LocalDate(date.Year, date.Month, date.Day),
                        TypeOfWork = typeOfWork
                    }));
        }

        
        public void AddTypeOfWorkByStaffAndDates(string staffUsername, DateTime startDate, DateTime endDate, string typeOfWork)
        {
            IList<TypeOfWorkByStaffAndDate> typeOfWorkByStaffAndDates = new List<TypeOfWorkByStaffAndDate>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                typeOfWorkByStaffAndDates.Add(new TypeOfWorkByStaffAndDate
                {
                    StaffUsername = staffUsername,
                    Date = new LocalDate(date.Year, date.Month, date.Day),
                    TypeOfWork = typeOfWork
                });
            }

            _typeOfWorkByStaffAndDateRepository.AddTypeOfWorkByStaffAndDates(typeOfWorkByStaffAndDates);
        }

        public void ChangeTypeOfWorkByStaffAndDate(string staffUsername, DateTime date, string newTypeOfWork)
        {
            _typeOfWorkByStaffAndDateRepository.ChangeTypeOfWorkByStaffAndDate(
                staffUsername,
                new LocalDate(date.Year, date.Month, date.Day),
                newTypeOfWork);
        }

        public IList<ExtendedTypeOfWorkBO> GetAllTypeOfWorkByCompany()
        {
            IList<TypeOfWorkByCompany> typesOfWorkByCompany = _typeOfWorkByCompanyRepository.GetAllTypeOfWorkByCompany();

            IList<ExtendedTypeOfWorkBO> typeOfWorkBOs = new List<ExtendedTypeOfWorkBO>();

            foreach (var typeOfWorkByCompany in typesOfWorkByCompany)
            {
                var typeOfWork = TypeOfWorkHelpers.MakeExtendedTypeOfWorkBOFromTypeOfWorkByCompany(typeOfWorkByCompany);
                typeOfWorkBOs.Add(typeOfWork);
            }

            return typeOfWorkBOs;
        }

        public IList<ExtendedTypeOfWorkBO> GetTypeOfWorkByCompany(string companyName)
        {
            IList<TypeOfWorkByCompany> typesOfWorkByCompany = _typeOfWorkByCompanyRepository.GetTypeOfWorkByCompany(companyName);

            IList<ExtendedTypeOfWorkBO> typeOfWorkBOs = new List<ExtendedTypeOfWorkBO>();

            foreach (var typeOfWorkByCompany in typesOfWorkByCompany)
            {
                var typeOfWork = TypeOfWorkHelpers.MakeExtendedTypeOfWorkBOFromTypeOfWorkByCompany(typeOfWorkByCompany);
                typeOfWorkBOs.Add(typeOfWork);
            }

            return typeOfWorkBOs;
        }

        public IList<ExtendedTypeOfWorkBO> GetTypeOfWorkByCompanyAndDate(string companyName, DateTime date)
        {
            IList<TypeOfWorkByCompany> typesOfWorkByCompany =
                _typeOfWorkByCompanyRepository
                .GetTypeOfWorkByCompanyAndDate(companyName, new LocalDate(date.Year, date.Month, date.Day));

            IList<ExtendedTypeOfWorkBO> typeOfWorkBOs = new List<ExtendedTypeOfWorkBO>();

            foreach (var typeOfWorkByCompany in typesOfWorkByCompany)
            {
                var typeOfWork = TypeOfWorkHelpers.MakeExtendedTypeOfWorkBOFromTypeOfWorkByCompany(typeOfWorkByCompany);
                typeOfWorkBOs.Add(typeOfWork);
            }

            return typeOfWorkBOs;
        }

        public string GetTypeOfWorkByCompanyDateAndStaffUsername(string companyName, DateTime date, string staffUsername)
        {
            return _typeOfWorkByCompanyRepository.GetTypeOfWorkByCompanyDateAndStaffUsername(
                companyName, new LocalDate(date.Year, date.Month, date.Day), staffUsername);
        }

        
        public void AddTypeOfWorkByCompany(ExtendedTypeOfWorkBO typeOfWorkBO)
        {
            _typeOfWorkByCompanyRepository.AddTypeOfWorkByCompany(
                TypeOfWorkHelpers.MakeTypeOfWorkByCompanyFromExtendedTypeOfWorkBO(
                    new ExtendedTypeOfWorkBO
                    {
                        CompanyName = typeOfWorkBO.CompanyName,
                        StaffUsername = typeOfWorkBO.StaffUsername,
                        Date = typeOfWorkBO.Date,
                        TypeOfWork = typeOfWorkBO.TypeOfWork
                    }));
        }

        public void AddTypesOfWorkByCompany(string companyName, DateTime startDate, DateTime endDate, string staffUsername, string typeOfWork)
        {
            IList<TypeOfWorkByCompany> typesOfWorkByCompany = new List<TypeOfWorkByCompany>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                typesOfWorkByCompany.Add(new TypeOfWorkByCompany
                {
                    CompanyName = companyName,
                    Date = new LocalDate(date.Year, date.Month, date.Day),
                    StaffUsername = staffUsername,
                    TypeOfWork = typeOfWork
                });
            }
            _typeOfWorkByCompanyRepository.AddTypesOfWorkByCompany(typesOfWorkByCompany);
        }

        public void ChangeTypeOfWorkByCompany(string companyName, DateTime date, string staffUsername, string newTypeOfWork)
        {
            _typeOfWorkByCompanyRepository.UpdateTypeOfWorkByCompany(
                new TypeOfWorkByCompany
                {
                    CompanyName = companyName,
                    Date = new LocalDate(date.Year, date.Month, date.Day),
                    StaffUsername = staffUsername,
                    TypeOfWork = newTypeOfWork
                });
        }

        public void AddTypeOfWork(ExtendedTypeOfWorkBO extendedTypeOfWorkBO)
        {
            DateTime dateTime = GeneralHelpers.ConvertLocalDateToDateTime(extendedTypeOfWorkBO.Date);

            //check if it is possible to work from office
            if (extendedTypeOfWorkBO.TypeOfWork == TypesOfWorkConstants.WFO)
            {
                if (!_checkWorkingFromOffice.Check(this, _companyService, extendedTypeOfWorkBO))
                {
                    throw new Exception($"Working from office is not possible for date {dateTime.ToShortDateString()}");
                }
            }

            //check if staff works for this company...
            var staff = _staffService.GetStaffByUsername(extendedTypeOfWorkBO.StaffUsername);
            if (staff == null || string.IsNullOrEmpty(staff.CompanyName) || staff.CompanyName != extendedTypeOfWorkBO.CompanyName)
            {
                throw new Exception($"Staff {staff.Username} doesn't work for {staff.CompanyName}");
            }

            //add type of work by staff and date
            AddTypeOfWorkByStaffAndDate(extendedTypeOfWorkBO.StaffUsername, dateTime, extendedTypeOfWorkBO.TypeOfWork);

            //add type of work by company
            AddTypeOfWorkByCompany(extendedTypeOfWorkBO);
        }

        public void AddTypesOfWork(string companyName, DateTime startDate, DateTime endDate, string staffUsername, string typeOfWork)
        {
            IList<DateTime> notAllowedDates = new List<DateTime>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var localDate = GeneralHelpers.ConvertDateTimeToLocalDate(date);
                var extendedTypeOfWorkBO = new ExtendedTypeOfWorkBO()
                {
                    CompanyName = companyName,
                    Date = localDate,
                    StaffUsername = staffUsername,
                    TypeOfWork = typeOfWork
                };

                try
                {
                    if (typeOfWork == TypesOfWorkConstants.WFO)
                    {
                        if (!_checkWorkingFromOffice.Check(this, _companyService, extendedTypeOfWorkBO))
                        {
                            throw new CantWFOException();
                        }
                    }

                    //check if staff works for this company...
                    var staff = _staffService.GetStaffByUsername(staffUsername);
                    if (staff == null || string.IsNullOrEmpty(staff.CompanyName) || staff.CompanyName != companyName)
                    {
                        throw new Exception($"Staff {staff.Username} doesn't work for {staff.CompanyName}");
                    }

                    //add type of work by staff and date
                    AddTypeOfWorkByStaffAndDate(extendedTypeOfWorkBO.StaffUsername, date, extendedTypeOfWorkBO.TypeOfWork);

                    //add type of work by company
                    AddTypeOfWorkByCompany(extendedTypeOfWorkBO);
                }
                catch (CantWFOException ex)
                {
                    notAllowedDates.Add(date);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (notAllowedDates.Count != 0)
            {
                var exceptionMessage = "Working from office is not possible for dates: \n";
                foreach(var notAllowedDate in notAllowedDates)
                {
                    exceptionMessage += $"{notAllowedDate.ToShortDateString()}\n";
                }
                throw new Exception(exceptionMessage);
            }
        }
    }
}
