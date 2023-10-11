
using Product.Application.Products.Queries;
using Product.Persistence;
using Product.Persistence.ViewModels;

namespace Product.Application.Products.QueryHandlers
{
    public class GetProductsQueryHandler : object,
        Mediator.IRequestHandler
        <Queries.GetProductsQuery, System.Collections.Generic.IEnumerable<GetProductsQueryResponseViewModel>>
    {
		public GetProductsQueryHandler
            (
			AutoMapper.IMapper mapper,
            IQueryUnitOfWork unitOfWork) : base()
		{
		
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected IQueryUnitOfWork UnitOfWork { get; }

		

		public
			async
		Task
			<FluentResults.Result
				<IEnumerable
				<GetProductsQueryResponseViewModel>>>
			Handle(GetProductsQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result
				<System.Collections.Generic.IEnumerable
				<GetProductsQueryResponseViewModel>>();

			try
			{
			
				var Products =
					await
					UnitOfWork.Products
					.GetSomeAsync(count: request.Count.Value)
					;
			

				result.WithValue(value: Products);
			
			}
			catch (System.Exception ex)
			{
			

				result.WithError
					(errorMessage: ex.Message);
			}

			return result;
		}

      
    }
}
