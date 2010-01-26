using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DomainModel.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using StructureMap;
using WebUI;

namespace SportsStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "null", // don't bother
                "", // matches the root url, i.e. ~/
                new { controller = "Products", action = "List", page = 1 }  // defaults
            );

            routes.MapRoute(
                null, // Don't bother giving this route entry a name
                "Page{page}", // URL pattern, e.g. ~/Page683
                new { controller = "Products", action = "List" }, // Defaults
                new { page = @"\d+" } // Constraints: page must be numerical
                );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            ContainerConfiguration.Configure();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }
    }
}