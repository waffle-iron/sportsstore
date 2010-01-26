using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using DomainModel.Abstract;
using DomainModel.Concrete;
using DomainModel.Entities;
using WebUI.Controllers;
using System.Web.Mvc;

namespace Tests
{
    [Subject("ProductsController")]
    public class when_products_controller_list_is_called
    {
        static Mock<IProductsRepository> productsRepository = new Mock<IProductsRepository>();
        static ViewResult result;
        static IList<Product> products = new List<Product> 
        { 
            new Product { Id = 1, Name = "name", Description = "description", Category = "category", Price = 1.99m }, 
            new Product { Id = 2, Name = "name", Description = "description", Category = "category", Price = 1.99m } 
        };

        Establish given =
            () =>
            {
                productsRepository.Setup(x => x.GetCount()).Returns(2);
                productsRepository.Setup(x => x.GetByPage(1, 2)).Returns(products);
            };

        Because when = () => result = new ProductsController(productsRepository.Object).List(1);

        Machine.Specifications.It should_return_the_correct_page;

        Machine.Specifications.It should_retrieve_a_list_of_all_products =
            () => productsRepository.Verify(x => x.GetByPage(1, 2));

        Machine.Specifications.It should_return_the_list_of_products_to_the_user =
            () => result.is_a_view_and().ViewData.Model.ShouldNotBeTheSameAs(products);

        //Machine.Specifications.It should_return_list_page = 
        //    () => result.is_a_view_and().ViewName.ShouldEqual<string>("List");
    }

    public static class TestExtensions
    {
        public static ViewResult is_a_view_and(this ActionResult result)
        {
            return result as ViewResult;
        }
    }
}
