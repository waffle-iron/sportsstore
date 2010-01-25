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
using DomainModel.Abstract;
using DomainModel.Concrete;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace WebUI
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IProductsRepository>()
                .Singleton()
                .Use(x=>x.GetInstance<ProductsRepository>());
        }
    }
}
