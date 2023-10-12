using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Controllers;
using Product.Application.Products.Commands;

namespace TestProduct
{
    [TestClass]
    public class UnitTestApi
    {
        [TestMethod]
        public void TestResultCreateProduct()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            ProductsController productsController = new ProductsController(mockMediator.Object);

            Task<IActionResult> result = productsController.Createproduct(Moq.It.IsAny<CreateProductCommand>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

        [TestMethod]
        public void TestResultGetProducts()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            ProductsController productsController = new ProductsController(mockMediator.Object);

            Task<IActionResult> result = productsController.GetProducts(Moq.It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

    }
}