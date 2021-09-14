using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanIT.DataAccess.Models;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PlanIT.Api.Models.MeetingRoomModels;

namespace PlanIT.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomsController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

        [HttpGet]
        [Route("meeting-rooms")]
        public ActionResult<IList<MeetingRoomBO>> GetAllMeetingRooms()
        {
            try
            {
                var meetingRooms = _meetingRoomService.GetAllMeetingRooms();

                return Ok(meetingRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("meeting-rooms/actions/get-by-company-name/{companyName}")]
        public ActionResult<IList<MeetingRoomBO>> GetMeetingRoomsByCompany([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var meetingRooms = _meetingRoomService.GetMeetingRoomsByCompany(companyName);

                return Ok(meetingRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("meeting-rooms/actions/get-by-company-name-and-meeting-room")]
        public ActionResult<MeetingRoomBO> GetMeetingRoomByCompanyAndMeetingRoom([FromBody] GetMeetingRoomByCompanyAndMeetingRoomRequest request)
        {
            try
            {
                var meetingRoom = _meetingRoomService.GetMeetingRoomByCompanyAndMeetingRoom(
                    request.CompanyName, request.MeetingRoom);

                return Ok(meetingRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("meeting-rooms")]
        [Authorize(Policy = "StaffCanCreate")]
        public ActionResult AddMeetingRoom([FromBody] MeetingRoomBO meetingRoomBO)
        {
            try
            {
                _meetingRoomService.AddMeetingRoom(meetingRoomBO);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("meeting-rooms")]
        public ActionResult UpdateMeetingRoomNumberOfSeats([FromBody] UpdateMeetingRoomNumberOfSeatsRequest request)
        {
            try
            {
                _meetingRoomService.UpdateMeetingRoomNumberOfSeats(
                    request.CompanyName, request.MeetingRoom, request.NewNumberOfSeats);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("meeting-rooms/actions/all-reserved")]
        public ActionResult GetAllReservedMeetingRoom()
        {
            try
            {
                var reservedMeetingRooms = _meetingRoomService.GetAllReservedMeetingRoom();

                return Ok(reservedMeetingRooms);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("meeting-rooms/actions/all-reserved-by-meeting-room-and-company")]
        public ActionResult GetReservedMeetingRoomByMeetingRoomAndCompany([FromBody] GetReservedMeetingRoomByMeetingRoomAndCompanyRequest request)
        {
            try
            {
                var reservedMeetingRooms = _meetingRoomService.GetReservedMeetingRoomByMeetingRoomAndCompany(request.MeetingRoom, request.CompanyName);

                return Ok(reservedMeetingRooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("meeting-rooms/actions/reserve")]
        public ActionResult ReserveMeetingRoom([FromBody] ReservedMeetingRoom reservedMeetingRoom)
        {
            try
            {
                _meetingRoomService.ReserveMeetingRoom(reservedMeetingRoom);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("meeting-rooms/actions/unreserve")]
        public ActionResult UnReserveMeetingRoom([FromBody] ReservedMeetingRoom reservedMeetingRoom)
        {
            try
            {
                _meetingRoomService.UnReserveMeetingRoom(reservedMeetingRoom);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
