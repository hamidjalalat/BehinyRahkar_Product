using Product.Persistence.ViewModels;

namespace Product.Application.Users.CommandHandlers
{
	public class GetByIdQueryHandler : 
		Mediator.IRequestHandler<Queries.GetByIdQuery,GetUsersQueryResponseViewModel>
	{
		public GetByIdQueryHandler
            (
			AutoMapper.IMapper mapper,
            Product.Persistence.IQueryUnitOfWork unitOfWork) : base()
		{
		
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected Product.Persistence.IQueryUnitOfWork UnitOfWork { get; }

		

		public
			async
			System.Threading.Tasks.Task
			<FluentResults.Result<GetUsersQueryResponseViewModel>>
			Handle(Queries.GetByIdQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result
				<GetUsersQueryResponseViewModel>();

			try
			{

				var Users =
					await
					UnitOfWork.Users
					.GetByIdAsync(request.Id);
					;

				var viewModel = Mapper.Map<GetUsersQueryResponseViewModel>(Users);

				result.WithValue(value: viewModel);
			
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
