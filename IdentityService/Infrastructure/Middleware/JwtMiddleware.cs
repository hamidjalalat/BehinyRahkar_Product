using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Product.Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure.Middleware
{
    public class JwtMiddleware
    {
    

        public JwtMiddleware(RequestDelegate next, MediatR.IMediator mediator)
        {
            Next = next;
            Mediator = mediator;
        }

        protected  RequestDelegate Next;

        protected MediatR.IMediator Mediator { get; }

        public async Task Invoke(HttpContext context, MediatR.IMediator mediator)
        {

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrWhiteSpace(token)==false)
            {
              await  JwtUtility.AttachUserToContextByToken(context, mediator,token, "behinrahkarbehinrahkhansarihamidjalalat");
            }

            await Next(context);
        }

    
    }
}
