using Microsoft.Extensions.Configuration;

namespace PlanIT.Service.BusinessLogic
{
    public class CovidCheckWorkingFromOffice : ICheckWorkingFromOffice
    {
        private readonly double _allowedPercentage = 50.0;

        public CovidCheckWorkingFromOffice(IConfiguration configuration)
        {
            _allowedPercentage = double.Parse(configuration["ApplicationConstants:AllowedPercentageInOffice"]);
        }

        public bool Check(int alreadyTakenPlaces, int allPlaces)
        {
            //+ 1 is because with this new staff, percentage taken can't be more than _allowedPercentage
            double percentageTaken = 100.0 * (((double)alreadyTakenPlaces + 1.0) / (double)allPlaces);

            //true-allowed percentage is more then taken => OK
            //false-allowed percentage is less then taken => NOT OK
            return _allowedPercentage >= percentageTaken;
        }
    }
}
