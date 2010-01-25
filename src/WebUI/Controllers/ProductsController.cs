using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomainModel.Abstract;
using DomainModel.Concrete;
using NHibernate;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ViewResult List()
        {
            return View(_productsRepository.GetAll());
        }

    }
}
