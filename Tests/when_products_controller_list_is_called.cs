using System.Collections.Generic;
using System.Web.Mvc;
using DomainModel.Abstract;
using DomainModel.Entities;
using Machine.Specifications;
using Moq;
using WebUI.Controllers;
using It=Moq.It;

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
                                                 new Product { Id = 2, Name = "name", Description = "description", Category = "category", Price = 1.99m }, 
                                             };

        Establish given =
            () =>
                {
                    productsRepository.Setup(x => x.GetCount()).Returns(products.Count);
                    productsRepository.Setup(x => x.GetByPage(It.IsAny<int>(), It.IsAny<int>())).Returns(products);
                };

        Because when = () => result = new ProductsController(productsRepository.Object).List(1);

        Machine.Specifications.It should_retrieve_a_list_of_products_by_current_page_and_page_size =
            () => productsRepository.Verify(x => x.GetByPage(It.IsAny<int>(), It.IsAny<int>()));

        Machine.Specifications.It should_return_the_list_of_products_to_the_user =
            () => result.is_a_view_and().ViewData.Model.ShouldBeTheSameAs(products);

        Machine.Specifications.It should_not_return_a_null_list_of_products =
            () =>
            {
                var actualProducts = result.is_a_view_and().ViewData.Model as IList<Product>;
                actualProducts.ShouldNotBeNull();
            };

        Machine.Specifications.It should_return_the_same_count_of_products =
            () =>
                {
                    var actualProducts = result.is_a_view_and().ViewData.Model as IList<Product>;
                    actualProducts.Count.ShouldEqual(products.Count);
                };
    }
}