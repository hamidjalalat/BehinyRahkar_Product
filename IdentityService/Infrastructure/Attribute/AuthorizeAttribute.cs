using Microsoft.AspNetCore.Mvc.Filters;
using Product.Domain.Models;
using Product.Persistence.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : System.Attribute, IAuthorizationFilter
    {
        public AuthorizeAttribute()
        {

        }
        public AuthorizeAttribute(string role)
        {
            Role = role;
        }


        public AuthorizeAttribute(string role, string service)
        {
            Role = role;
            Service = service;
        }
        public string Role { get; set; }
        public string Service { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string rol = Role;
            GetUsersQueryResponseViewModel user = context.HttpContext.Items["User"] as GetUsersQueryResponseViewModel;

            if (user == null)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.
                    JsonResult(new { message = "unauthorized" })
                {
                    StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                };
            }
            else
            {
             
                if (user.Role.Trim().ToLower() != Role.ToLower().Trim() && Role.ToLower().Trim() != "*")
                {
                    context.Result = new Microsoft.AspNetCore.Mvc.
                      JsonResult(new { message = "You do not have access " })
                    {
                        StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                    };
                }
                
                var Services = user.Services.Split(',');
                var isService = Services.Contains(Service);

                if (!isService)
                {
                    context.Result = new Microsoft.AspNetCore.Mvc.
                    JsonResult(new { message = "You do not have access " })
                    {
                        StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                    };
                }
            }

        }
    }
}
