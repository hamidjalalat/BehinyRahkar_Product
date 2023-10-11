using Product.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Product.Application.Products.Commands;
using Product.Application.Products.Queries;

namespace Product.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Mvc.Route
        (template: "[controller]")]
    public class ProductsController : Product.Infrastructure.ControllerBase
    {
        public ProductsController(MediatR.IMediator mediator) : base(mediator: mediator)
        {
        }

        #region Post (Create product)
        [Infrastructure.Attribute.Authorize(role:"Admin",service:"pd")]
        [Microsoft.AspNetCore.Mvc.HttpPost(template: "/product")]

        public async Task<IActionResult>
            Createproduct(CreateProductCommand request)
        {
            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Create product)


        #region Get (Get products)
        [Infrastructure.Attribute.Authorize(role: "*",service: "pd")]
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "/products/{count}")]
        public async Task<IActionResult> GetProducts(int? count)
        {
            var request =
                new GetProductsQuery
                {
                    Count= count,
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion Get (Get products)

    }
}
