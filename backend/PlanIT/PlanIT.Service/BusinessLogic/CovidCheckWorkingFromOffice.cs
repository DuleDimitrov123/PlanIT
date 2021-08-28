using PlanIT.Repository.Constants;
using PlanIT.Repository.Helpers;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using System.Linq;

namespace PlanIT.Service.BusinessLogic
{
    public class CovidCheckWorkingFromOffice : ICheckWorkingFromOffice
    {
        //maybe consider finding a better way than private field...
        private readonly double _availablePercentage = 50.0;

        public bool Check(ITypeOfWorkService typeOfWorkService, ICompanyService companyService, ExtendedTypeOfWorkBO extendedTypeOfWorkBO)
        {
            var company = companyService.GetCompanyByName(extendedTypeOfWorkBO.CompanyName);

            if(company == null)
            {
                throw new Exception($"Company {extendedTypeOfWorkBO.CompanyName} doens't exist!");
            }

            var typeOfWork = typeOfWorkService.GetTypeOfWorkByCompanyAndDate(
                extendedTypeOfWorkBO.CompanyName, GeneralHelpers.ConvertLocalDateToDateTime(extendedTypeOfWorkBO.Date));
            var typeOfWorkWFO = typeOfWork.Where(t => t.TypeOfWork == TypesOfWorkConstants.WFO).ToList();
            double percentageTaken = 100.0 * ((double)typeOfWorkWFO.Count / (double)company.NumberOfWorkplaces);

            //true-available percentage is more then taken => OK
            //false-available percentage is less then taken => NOT OK
            return _availablePercentage > percentageTaken;
        }
    }
}
