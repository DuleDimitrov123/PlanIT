using Cassandra;
using PlanIT.DataAccess.Constants;

namespace PlanIT.Repository
{
    public static class SessionManager
    {
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
