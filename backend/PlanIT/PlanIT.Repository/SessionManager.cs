using Cassandra;
using PlanIT.DataAccess.Constants;
using Cassandra.Mapping;
using PlanIT.Repository.Mappings;

namespace PlanIT.Repository
{
    public static class SessionManager
    {
        static SessionManager()
        {
            MappingConfiguration.Global.Define<PlanITMappings>();
        }

        private static ISession session;

        public static ISession GetSession()
        {
            if (session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                session = cluster.Connect(DatabaseNames.KeyspaceName);
            }
            return session;
        }
    }
}
