using Product.Persistence.ViewModels;

namespace Product.Application.Products.Queries
{
	public class GetProductsQuery : Mediator.IRequest
		<IEnumerable<GetProductsQueryResponseViewModel>>
	{
		public GetProductsQuery() : base()
		{
		}

		public int? Count { get; set; }
	}
}
