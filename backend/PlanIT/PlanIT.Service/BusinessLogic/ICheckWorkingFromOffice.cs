namespace PlanIT.Service.BusinessLogic
{
    public interface ICheckWorkingFromOffice
    {
        bool Check(int alreadyTakenPlaces, int allPlaces);
    }
}
