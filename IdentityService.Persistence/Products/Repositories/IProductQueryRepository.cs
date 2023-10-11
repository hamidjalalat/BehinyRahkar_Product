using Product.Domain.Models;
using Product.Persistence.ViewModels;

namespace Product.Persistence.Repositories
{
	public interface IProductQueryRepository : Product.Persistence.Base.IQueryRepository<Product.Domain.Models.Product>
	{
		Task
			<IList<GetProductsQueryResponseViewModel>>
			GetSomeAsync(int count);

     
    }
}
