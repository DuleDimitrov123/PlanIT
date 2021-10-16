using PlanIT.DataAccess.Models;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IProfilePictureByStaffRepository
    {
        string GetProfilePicture(string staffUsername);

        void AddProfilePicture(ProfilePictureByStaff profilePictureByStaff);

        void DeleteProfilePicture(string staffUsername);
    }
}
