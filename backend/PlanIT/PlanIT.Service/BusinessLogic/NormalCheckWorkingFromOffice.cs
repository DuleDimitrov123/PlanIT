using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;

namespace PlanIT.Service.BusinessLogic
{
    public class NormalCheckWorkingFromOffice : ICheckWorkingFromOffice
    {
        public bool Check(ITypeOfWorkService typeOfWorkService, ICompanyService companyService, ExtendedTypeOfWorkBO extendedTypeOfWorkBO)
        {
            return true;
        }
    }
}
