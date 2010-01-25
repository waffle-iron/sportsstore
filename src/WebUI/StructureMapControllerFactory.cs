using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using StructureMap;

namespace WebUI
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(Type controllerType)
        {
            IController controller;
            if (controllerType == null)
            {

                return base.GetControllerInstance(controllerType);
            }
            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException("Not a valid controller");
            }
            try
            {
                //The magic happens here.
                //When MVC tries to get an instance of the appropriate controller class, we ask StructureMap to create it
                //We don't actually have to register the controller with StructureMap, it will create anything we ask for.
                //What it will do though is populate the controller with dependencies if it knows about them.
                //See the HomeController for an example.
                controller = (IController)ObjectFactory.GetInstance(controllerType);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(string.Format("Error Creating Controller - {0}", new object[] { controllerType }), exception);
            }
            return controller;

        }

    }
}
