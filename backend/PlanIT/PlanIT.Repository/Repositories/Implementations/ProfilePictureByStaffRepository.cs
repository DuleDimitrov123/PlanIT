using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Linq;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class ProfilePictureByStaffRepository : IProfilePictureByStaffRepository
    {
        public string GetProfilePicture(string staffUsername)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            ProfilePictureByStaff profilePictureByStaff = mapper.Fetch<ProfilePictureByStaff>
                ($"WHERE \"{ProfilePictureByStaffColumns.StaffUsername}\" = ?", staffUsername)
                .FirstOrDefault();

            return profilePictureByStaff?.Content;
        }

        public void AddProfilePicture(ProfilePictureByStaff profilePictureByStaff)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(profilePictureByStaff);
        }

        public void DeleteProfilePicture(string staffUsername)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.DeleteIf<ProfilePictureByStaff>($"WHERE \"{ProfilePictureByStaffColumns.StaffUsername}\" = ?", staffUsername);
        }
    }
}
