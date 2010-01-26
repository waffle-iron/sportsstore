using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NHibernate;
using NHibernate.Context;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace WebUI
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            For<ISessionFactory>()
                .Singleton()
                .Use(ThreadSafeSessionManager.SessionFactory);

            For<ISession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x => x.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}
