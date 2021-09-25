namespace PlanIT.Service.BusinessLogic
{
    public class NormalCheckWorkingFromOffice : ICheckWorkingFromOffice
    {
        public bool Check(int alreadyTakenPlaces, int allPlaces)
        {
            return alreadyTakenPlaces + 1 <= allPlaces;
        }
    }
}
