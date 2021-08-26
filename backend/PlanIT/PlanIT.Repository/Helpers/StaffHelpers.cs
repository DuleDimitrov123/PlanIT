using Cassandra;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanIT.Repository.Helpers
{
    public static class StaffHelpers
    {
        public static IList<StaffCanCreateByCompany> CreateStaffCanCreateByCompanyFromRowSet(RowSet rowSet)
        {
            IList<StaffCanCreateByCompany> staffCanCreateByCompanies = new List<StaffCanCreateByCompany>();

            foreach(var row in rowSet)
            {
                staffCanCreateByCompanies.Add(CreateStaffCanCreateByCompanyFromRow(row));
            }

            return staffCanCreateByCompanies;
        }

        public static StaffCanCreateByCompany CreateStaffCanCreateByCompanyFromRow(Row row) => new StaffCanCreateByCompany
        {
            CompanyName = row[StaffCanCreateByCompanyColumns.CompanyName] != null ?
                row[StaffCanCreateByCompanyColumns.CompanyName].ToString()
                : string.Empty,
            StaffUsernames = row[StaffCanCreateByCompanyColumns.StaffUsernames] != null ?
                (IList<string>)row[StaffCanCreateByCompanyColumns.StaffUsernames]
                : null
        };
    }
}
