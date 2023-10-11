using Product.Application.Products.Commands;
using Product.Persistence.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Users
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() : base()
        {

            CreateMap<GetUsersQueryResponseViewModel, Domain.Models.User>();
            CreateMap<Domain.Models.User, GetUsersQueryResponseViewModel>();

            CreateMap<CreateProductCommand, Domain.Models.Product>();
            CreateMap<Domain.Models.Product, CreateProductCommand>();
        }
    }
}
