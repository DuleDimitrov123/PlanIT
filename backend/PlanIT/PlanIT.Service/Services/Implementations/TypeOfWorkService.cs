using Cassandra;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Repositories.Contracts;
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

        public TypeOfWorkService(ITypeOfWorkByStaffAndDateRepository typeOfWorkByStaffAndDateRepository)
        {
            _typeOfWorkByStaffAndDateRepository = typeOfWorkByStaffAndDateRepository;
        }

        public IList<TypeOfWorkBO> GetAllTypeOfWorkByStaffAndDate()
        {
            IList<TypeOfWorkByStaffAndDate> typeOfWorkByStaffAndDates = _typeOfWorkByStaffAndDateRepository.GetAllTypeOfWorkByStaffAndDate();
            IList<TypeOfWorkBO> typeOfWorkBOs = new List<TypeOfWorkBO>();

            foreach(var type in typeOfWorkByStaffAndDates)
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

        public void ChangeTypeOfWorkByStaffAndDate(string staffUsername, DateTime date, string newTypeOfWork)
        {
            throw new System.NotImplementedException();
        }
    }
}
