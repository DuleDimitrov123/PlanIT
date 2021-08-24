using PlanIT.DataAccess;
using PlanIT.DataAccess.Constants;

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
                .Column(c => c.Description, cm => cm.WithName(CompanyColumns.Description).WithDbType<string>()).CaseSensitive();
        }
    }
}
