using Cassandra;
using PlanIT.DataAccess.Constants;
using System.Collections.Generic;

namespace PlanIT.DataAccess.Helpers
{
    public static class CompanyHelper
    {
        public static Company CreateCompanyFromRow(Row row)
        {
            Company company = new Company();
            company.CompanyName = row[CompanyColumns.CompanyName] != null ? row[CompanyColumns.CompanyName].ToString() : string.Empty;
            company.Address = row[CompanyColumns.Address] != null ? row[CompanyColumns.Address].ToString() : string.Empty;
            company.City = row[CompanyColumns.City] != null ? row[CompanyColumns.City].ToString() : string.Empty;
            company.Country = row[CompanyColumns.Country] != null ? row[CompanyColumns.Country].ToString() : string.Empty;
            company.Description = row[CompanyColumns.Description] != null ? row[CompanyColumns.Description].ToString() : string.Empty;

            return company;
        }

        public static IList<Company> CreateCompanyFromRowSet(RowSet rowSet)
        {
            IList<Company> companies = new List<Company>();

            foreach (var row in rowSet)
            {
                companies.Add(CreateCompanyFromRow(row));
            }

            return companies;
        }
    }
}
