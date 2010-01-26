using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DomainModel.Abstract;
using DomainModel.Concrete;
using NHibernate;
using DomainModel.Entities;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        public int PageSize = 4;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        //public ViewResult List()
        //{
        //    return View(_productsRepository.GetAll());
        //}

        public ViewResult List(int page)
        {
            int numProducts = _productsRepository.GetCount();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)numProducts / PageSize);
            ViewData["CurrentPage"] = page;

            //var p1 = new Product { Name = "p1", Description = "", Category = "", Price = 0 };
            //_productsRepository.Add(p1);
            //var p2 = new Product { Name = null, Description = "", Category = "", Price = 0 };
            //_productsRepository.Add(p2);

            return View(_productsRepository.GetByPage(page, PageSize));
        }

    }
}
