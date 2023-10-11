using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Product.Application.Users.Queries;
using Product.Domain.Models;
using Product.Persistence.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Infrastructure
{
    public static class JwtUtility
    {
        static JwtUtility()
        {

        }
    

        public static async Task attachUserToContextByToken(HttpContext context, MediatR.IMediator mediator, string token,string secretKey)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken =  validatedToken as JwtSecurityToken;

                if (jwtToken==null)
                {
                    return;
                }

                Claim userIdClaim = jwtToken.Claims.Where(C => C.Type.ToLower() == "NameId".ToLower()).FirstOrDefault();
                if (userIdClaim==null)
                {
                    return;
                }
                var userId = Guid.Parse(userIdClaim.Value);

                //این کار برای محکم کاری  که اگر کاربر در دیتابس پاک یا غیر فعال شد جلوگیری بشود  
               var request =
               new GetByIdQuery
               {
                  Id= userId,
               };

               FluentResults.Result<GetUsersQueryResponseViewModel>  foundedUser =
               await  mediator.Send(request);


                if (foundedUser.IsFailed)
                {
                    return;
                }
                //***
                context.Items["User"] = foundedUser.Value;

            }
            catch(Exception ex)
            {
                //عملیات لاگ گذاری
            }
        }

    }
}
