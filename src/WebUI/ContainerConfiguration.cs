using StructureMap;

namespace WebUI
{
    public class ContainerConfiguration
    {
        public static void Configure()
        {
            ObjectFactory.Configure(InitStructureMap);
        }

        private static void InitStructureMap(ConfigurationExpression configurationExpression)
        {
            configurationExpression.AddRegistry(new NHibernateRegistry());
            configurationExpression.AddRegistry(new RepositoryRegistry());
        }
    }
}
