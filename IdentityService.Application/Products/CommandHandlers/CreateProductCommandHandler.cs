

using System.Resources;
using Product.Application.Products.Commands;

namespace Product.Application.Products.CommandHandlers
{
    public class CreateProductCommandHandler : Mediator.IRequestHandler
        <Product.Application.Products.Commands.CreateProductCommand, Guid>
    {
        public CreateProductCommandHandler
            (
            AutoMapper.IMapper mapper,
            Persistence.IUnitOfWork unitOfWork) : base()
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        protected AutoMapper.IMapper Mapper { get; }

        protected Persistence.IUnitOfWork UnitOfWork { get; }



        public async Task<FluentResults.Result<Guid>>
            Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var result =
                new FluentResults.Result<Guid>();

            try
            {
                var Product = Mapper.Map<Domain.Models.Product>(source: request);
             
                await UnitOfWork.Products.InsertAsync(entity: Product);

                await UnitOfWork.SaveAsync();
             
                result.WithValue(value: Product.Id);
                string successInsert =
                    string.Format("عملیات درج با موفقیت انجام شد");

                result.WithSuccess
                    (successMessage: successInsert);
            }
            catch (Exception ex)
            {


                result.WithError
                    (errorMessage: ex.Message);
            }

            return result;
        }
    }
}
