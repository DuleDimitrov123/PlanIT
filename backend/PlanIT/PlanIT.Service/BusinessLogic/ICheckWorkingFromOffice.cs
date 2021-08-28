using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;

namespace PlanIT.Service.BusinessLogic
{
    public interface ICheckWorkingFromOffice
    {
        bool Check(ITypeOfWorkService typeOfWorkService, ICompanyService companyService, ExtendedTypeOfWorkBO extendedTypeOfWorkBO);
    }
}
