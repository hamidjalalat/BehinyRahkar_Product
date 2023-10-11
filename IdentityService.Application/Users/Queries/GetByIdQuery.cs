using Product.Persistence.ViewModels;

namespace Product.Application.Users.Queries
{
	public class GetByIdQuery : object,
		Mediator.IRequest
		<GetUsersQueryResponseViewModel>
	{
		public GetByIdQuery() : base()
		{
		}

		public Guid Id { get; set; }
	}
}
