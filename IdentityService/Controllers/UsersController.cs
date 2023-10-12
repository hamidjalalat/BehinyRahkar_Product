using Product.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Product.Application.Products.Commands;

namespace Product.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Mvc.Route
        (template: "[controller]")]
    public class UsersController : Product.Infrastructure.ControllerBase
    {
        public UsersController(MediatR.IMediator mediator) : base(mediator: mediator)
        {
        }

        #region Post (Get User)
        [Microsoft.AspNetCore.Mvc.HttpPost(template: "/GetUser")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var request =
                new GetByUserNameQuery
                {
                    UserName = username,
                    Password = password,
                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion Post (Get User)
    }
}
