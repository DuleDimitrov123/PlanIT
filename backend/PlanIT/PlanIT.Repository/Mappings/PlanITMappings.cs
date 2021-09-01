using Cassandra;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using System;
using System.Collections.Generic;

namespace PlanIT.Repository.Mappings
{
    public class PlanITMappings : Cassandra.Mapping.Mappings
    {
        public PlanITMappings()
        {
            For<Company>()
                .TableName(DatabaseNames.Company).CaseSensitive()
                .PartitionKey(c => c.CompanyName)
                .Column(c => c.CompanyName, cm => cm.WithName(CompanyColumns.CompanyName)).CaseSensitive()
                .Column(c => c.Country, cm => cm.WithName(CompanyColumns.Country).WithDbType<string>()).CaseSensitive()
                .Column(c => c.City, cm => cm.WithName(CompanyColumns.City).WithDbType<string>()).CaseSensitive()
                .Column(c => c.Address, cm => cm.WithName(CompanyColumns.Address).WithDbType<string>()).CaseSensitive()
                .Column(c => c.Description, cm => cm.WithName(CompanyColumns.Description).WithDbType<string>()).CaseSensitive()
                .Column(c => c.NumberOfWorkplaces, cm => cm.WithName(CompanyColumns.NumberOfWorkplaces).WithDbType<int>()).CaseSensitive();

            For<Staff>()
                .TableName(DatabaseNames.Staff).CaseSensitive()
                .PartitionKey(s => s.Username)
                .Column(s => s.Username, cm => cm.WithName(StaffColumns.Username).WithDbType<string>()).CaseSensitive()
                .Column(s => s.Password, cm => cm.WithName(StaffColumns.Password).WithDbType<string>()).CaseSensitive()
                .Column(s => s.FirstName, cm => cm.WithName(StaffColumns.FirstName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.LastName, cm => cm.WithName(StaffColumns.LastName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.DateOfBirth, cm => cm.WithName(StaffColumns.DateOfBirth).WithDbType<LocalDate>()).CaseSensitive()
                .Column(s => s.CompanyName, cm => cm.WithName(StaffColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.Position, cm => cm.WithName(StaffColumns.Position).WithDbType<string>()).CaseSensitive()
                .Column(s => s.CanCreate, cm => cm.WithName(StaffColumns.CanCreate).WithDbType<bool>()).CaseSensitive();

            For<StaffCanCreateByCompany>()
                .TableName(DatabaseNames.StaffCanCreateByCompany).CaseSensitive()
                .PartitionKey(s => s.CompanyName)
                .Column(s => s.CompanyName, cm => cm.WithName(StaffCanCreateByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.StaffUsernames, cm => cm.WithName(StaffCanCreateByCompanyColumns.StaffUsernames).WithDbType<List<string>>()).CaseSensitive();

            For<StaffByCompany>()
                .TableName(DatabaseNames.StaffByCompany).CaseSensitive()
                .PartitionKey(s => s.CompanyName)
                .ClusteringKey(s => s.StaffUsername)
                .Column(s => s.CompanyName, cm => cm.WithName(StaffByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(s => s.StaffUsername, cm => cm.WithName(StaffByCompanyColumns.StaffUsername).WithDbType<string>()).CaseSensitive()
                .Column(s => s.Position, cm => cm.WithName(StaffByCompanyColumns.Position).WithDbType<string>()).CaseSensitive();

            For<TypeOfWorkByStaffAndDate>()
                .TableName(DatabaseNames.TypeOfWorkByStaffAndDate).CaseSensitive()
                .PartitionKey(t => t.StaffUsername)
                .ClusteringKey(t => t.Date)
                .Column(t => t.StaffUsername, cm => cm.WithName(TypeOfWorkByStaffAndDateColumns.StaffUsername).WithDbType<string>()).CaseSensitive()
                .Column(t => t.Date, cm => cm.WithName(TypeOfWorkByStaffAndDateColumns.Date).WithDbType<LocalDate>()).CaseSensitive()
                .Column(t => t.TypeOfWork, cm => cm.WithName(TypeOfWorkByStaffAndDateColumns.TypeOfWork).WithDbType<string>()).CaseSensitive();

            For<TypeOfWorkByCompany>()
                .TableName(DatabaseNames.TypeOfWorkByCompany).CaseSensitive()
                .PartitionKey(t => t.CompanyName)
                .ClusteringKey(t => t.Date)
                .ClusteringKey(t => t.StaffUsername)
                .Column(t => t.CompanyName, cm => cm.WithName(TypeOfWorkByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(t => t.Date, cm => cm.WithName(TypeOfWorkByCompanyColumns.Date).WithDbType<LocalDate>()).CaseSensitive()
                .Column(t => t.StaffUsername, cm => cm.WithName(TypeOfWorkByCompanyColumns.StaffUsername).WithDbType<string>()).CaseSensitive()
                .Column(t => t.TypeOfWork, cm => cm.WithName(TypeOfWorkByCompanyColumns.TypeOfWork).WithDbType<string>()).CaseSensitive();

            For<MeetingRoomByCompany>()
                .TableName(DatabaseNames.MeetingRoomByCompany).CaseSensitive()
                .PartitionKey(m => m.CompanyName)
                .ClusteringKey(m => m.MeetingRoom)
                .Column(m => m.CompanyName, cm => cm.WithName(MeetingRoomByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(m => m.MeetingRoom, cm => cm.WithName(MeetingRoomByCompanyColumns.MeetingRoom).WithDbType<string>()).CaseSensitive()
                .Column(m => m.NumberOfSeats, cm => cm.WithName(MeetingRoomByCompanyColumns.NumberOfSeats).WithDbType<int>()).CaseSensitive();

            For<ReservedMeetingRoom>()
                .TableName(DatabaseNames.ReservedMeetingRoom).CaseSensitive()
                .PartitionKey(a => a.MeetingRoom)
                .PartitionKey(a => a.CompanyName)
                .ClusteringKey(a => a.StartDateTime)
                .ClusteringKey(a => a.EndDateTime)
                .Column(a => a.MeetingRoom, cm => cm.WithName(ReservedMeetingRoomColumns.MeetingRoom).WithDbType<string>()).CaseSensitive()
                .Column(a => a.CompanyName, cm => cm.WithName(ReservedMeetingRoomColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(a => a.StartDateTime, cm => cm.WithName(ReservedMeetingRoomColumns.StartDateTime).WithDbType<DateTimeOffset>()).CaseSensitive()
                .Column(a => a.EndDateTime, cm => cm.WithName(ReservedMeetingRoomColumns.EndDateTime).WithDbType<DateTimeOffset>()).CaseSensitive()
                .Column(a => a.StaffUsernameWhoReserved, cm => cm.WithName(ReservedMeetingRoomColumns.StaffUsernameWhoReserved).WithDbType<string>()).CaseSensitive()
                .Column(a => a.NumberOfSeatsUsed, cm => cm.WithName(ReservedMeetingRoomColumns.NumberOfSeatsUsed).WithDbType<int>()).CaseSensitive();

            For<AvailableBreakfastByCompany>()
                .TableName(DatabaseNames.AvailableBreakfastByCompany).CaseSensitive()
                .PartitionKey(a => a.CompanyName)
                .ClusteringKey(a => a.Date)
                .Column(a => a.CompanyName, cm => cm.WithName(AvailableBreakfastByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(a => a.Date, cm => cm.WithName(AvailableBreakfastByCompanyColumns.Date).WithDbType<LocalDate>()).CaseSensitive()
                .Column(a => a.BreakfastItems, cm => cm.WithName(AvailableBreakfastByCompanyColumns.BreakfastItems).WithDbType<IList<string>>()).CaseSensitive();

            For<BreakfastByStaff>()
                .TableName(DatabaseNames.BreakfastByStaff).CaseSensitive()
                .PartitionKey(b => b.StaffUsername)
                .ClusteringKey(b => b.Date)
                .Column(b => b.StaffUsername, cm => cm.WithName(BreakfastByStaffColumns.StaffUsername).WithDbType<string>()).CaseSensitive()
                .Column(b => b.Date, cm => cm.WithName(BreakfastByStaffColumns.Date).WithDbType<LocalDate>()).CaseSensitive()
                .Column(b => b.BreakfastItems, cm => cm.WithName(BreakfastByStaffColumns.BreakfastItems).WithDbType<IList<string>>()).CaseSensitive();

            For<BreakfastByCompany>()
                .TableName(DatabaseNames.BreakfastByCompany).CaseSensitive()
                .PartitionKey(b => b.CompanyName)
                .ClusteringKey(b => b.Date)
                .ClusteringKey(b => b.StaffUsername)
                .Column(b => b.CompanyName, cm => cm.WithName(BreakfastByCompanyColumns.CompanyName).WithDbType<string>()).CaseSensitive()
                .Column(b => b.Date, cm => cm.WithName(BreakfastByCompanyColumns.Date).WithDbType<LocalDate>()).CaseSensitive()
                .Column(b => b.StaffUsername, cm => cm.WithName(BreakfastByCompanyColumns.StaffUsername).WithDbType<string>()).CaseSensitive()
                .Column(b => b.BreakfastItems, cm => cm.WithName(BreakfastByCompanyColumns.BreakfastItems).WithDbType<IList<string>>()).CaseSensitive();
        }
    }
}
