using DomainModel.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace WebUI
{
    public class ThreadSafeSessionManager
    {
        private readonly ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get { return Instance._sessionFactory; }
        }

        private ISessionFactory GetSessionFactory()
        {
            return _sessionFactory;
        }

        public static ThreadSafeSessionManager Instance
        {
            get {
                return NestedSessionManager.SessionManager; }
        }

        public static ISession OpenSession()
        {
            return Instance.GetSessionFactory().OpenSession();
        }

        public static ISession CurrentSession
        {
            get
            {
                return Instance.GetSessionFactory().GetCurrentSession();
            }
        }

        private ThreadSafeSessionManager()
        {
            _sessionFactory = Fluently.Configure()
              .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "managed_web"))
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("SportsStore")))
              .Mappings(m =>
                m.AutoMappings.Add(
                  AutoMap.AssemblyOf<Product>(type => type.Namespace.EndsWith("Entities"))))
              .BuildSessionFactory();
        }

        class NestedSessionManager
        {
            internal static readonly ThreadSafeSessionManager SessionManager = new ThreadSafeSessionManager();
        }
    }
}
