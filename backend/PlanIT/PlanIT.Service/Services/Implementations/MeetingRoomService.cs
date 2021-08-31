using PlanIT.DataAccess.Models;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.BusinessLogic;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Helpers;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanIT.Service.Services.Implementations
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IMeetingRoomByCompanyRepository _meetingRoomByCompanyRepository;
        private readonly IReservedMeetingRoomRepository _reservedMeetingRoomRepository;
        private readonly IAllowedNumberInMeetingRoom _allowedNumberInMeetingRoom;

        public MeetingRoomService(
            IMeetingRoomByCompanyRepository meetingRoomByCompanyRepository,
            IReservedMeetingRoomRepository reservedMeetingRoomRepository,
            IAllowedNumberInMeetingRoom allowedNumberInMeetingRoom)
        {
            _meetingRoomByCompanyRepository = meetingRoomByCompanyRepository;
            _reservedMeetingRoomRepository = reservedMeetingRoomRepository;
            _allowedNumberInMeetingRoom = allowedNumberInMeetingRoom;
        }

        public IList<MeetingRoomBO> GetAllMeetingRooms()
        {
            var meetingRoomsByCompany = _meetingRoomByCompanyRepository.GetAllMeetingRoomByCompany();
            IList<MeetingRoomBO> meetingRoomBOs = new List<MeetingRoomBO>();

            foreach (var meetingRoomByCompany in meetingRoomsByCompany)
            {
                meetingRoomBOs.Add(
                    MeetingRoomServiceHelpers.MakeMeetingRoomBOFromMeetingRoomByCompany(meetingRoomByCompany));
            }

            return meetingRoomBOs;
        }

        public IList<MeetingRoomBO> GetMeetingRoomsByCompany(string companyName)
        {
            var meetingRoomsByCompany = _meetingRoomByCompanyRepository.GetMeetingRoomsByCompany(companyName);
            IList<MeetingRoomBO> meetingRoomBOs = new List<MeetingRoomBO>();

            foreach (var meetingRoomByCompany in meetingRoomsByCompany)
            {
                meetingRoomBOs.Add(
                    MeetingRoomServiceHelpers.MakeMeetingRoomBOFromMeetingRoomByCompany(meetingRoomByCompany));
            }

            return meetingRoomBOs;
        }


        public MeetingRoomBO GetMeetingRoomByCompanyAndMeetingRoom(string companyName, string meetingRoom)
        {
            var meetingRoomByCompany = _meetingRoomByCompanyRepository.GetMeetingRoomByCompanyAndMeetingRoom(companyName, meetingRoom);

            return MeetingRoomServiceHelpers.MakeMeetingRoomBOFromMeetingRoomByCompany(meetingRoomByCompany);
        }

        public void AddMeetingRoom(MeetingRoomBO meetingRoomBO)
        {
            _meetingRoomByCompanyRepository.AddMeetingRoomByCompany(
                MeetingRoomServiceHelpers.MakeMeetingRoomByCompanyFromMeetingRoomBO(meetingRoomBO));
        }

        public void UpdateMeetingRoomNumberOfSeats(string companyName, string meetingRoom, int newNumberOfSeats)
        {
            _meetingRoomByCompanyRepository.UpdateMeetingRoomByCompany(
                new MeetingRoomByCompany
                {
                    CompanyName = companyName,
                    MeetingRoom = meetingRoom,
                    NumberOfSeats = newNumberOfSeats
                });
        }

        public IList<ReservedMeetingRoom> GetAllReservedMeetingRoom()
        {
            return _reservedMeetingRoomRepository.GetAllReservedMeetingRoom();
        }

        public IList<ReservedMeetingRoom> GetReservedMeetingRoomByMeetingRoomAndCompany(string meetingRoom, string companyName)
        {
            return _reservedMeetingRoomRepository.GetReservedMeetingRoomByMeetingRoomAndCompany(meetingRoom, companyName);
        }

        public void ReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom)
        {
            IList<ReservedMeetingRoom> allReserved = new List<ReservedMeetingRoom>();
            string message = "";
            try
            {
                allReserved = _reservedMeetingRoomRepository.GetReservedMeetingRoomByMeetingRoomAndCompany(
                     reservedMeetingRoom.MeetingRoom, reservedMeetingRoom.CompanyName).
                     OrderBy(rmr => rmr.StartDateTime).ToList();

                bool isPossible = true;

                int i = 0;
                for (i = 0; i <= allReserved.Count() - 2; i++)
                {
                    if (reservedMeetingRoom.StartDateTime <= allReserved.ElementAt(i).EndDateTime && allReserved.ElementAt(i).StartDateTime <= reservedMeetingRoom.EndDateTime)
                    {
                        isPossible = false;
                    }

                    if (allReserved.ElementAt(i).EndDateTime != allReserved.ElementAt(i + 1).StartDateTime)
                    {
                        message += $", or between {allReserved.ElementAt(i).EndDateTime.DateTime.ToShortTimeString()} and {allReserved.ElementAt(i + 1).StartDateTime.DateTime.ToShortTimeString()}";
                    }
                }

                if (i < allReserved.Count())
                {
                    if (reservedMeetingRoom.StartDateTime <= allReserved.ElementAt(i).EndDateTime && allReserved.ElementAt(i).StartDateTime <= reservedMeetingRoom.EndDateTime)
                    {
                        isPossible = false;
                    }
                }

                if (!isPossible)
                {
                    throw new NotAvailableMeetingRoomException();
                }

                if (_allowedNumberInMeetingRoom.IsAllowed(this, reservedMeetingRoom))
                {
                    _reservedMeetingRoomRepository.ReserveMeetingRoom(reservedMeetingRoom);
                }
            }
            catch (NotAvailableMeetingRoomException ex)
            {
                message = $"It is not possible to reserve {reservedMeetingRoom.MeetingRoom} " +
                        $"from {reservedMeetingRoom.StartDateTime.DateTime.ToString()} to {reservedMeetingRoom.EndDateTime.DateTime.ToString()}. You can reserve before {allReserved.ElementAt(0).StartDateTime.DateTime.ToShortTimeString()}, "
                        + $"or after {allReserved.ElementAt(allReserved.Count() - 1).EndDateTime.DateTime.ToShortTimeString()}" + message;

                throw new Exception(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UnReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom)
        {
            _reservedMeetingRoomRepository.UnReserveMeetingRoom(reservedMeetingRoom);
        }
    }
}
