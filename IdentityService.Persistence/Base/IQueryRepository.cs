using Product.Domain.Models.Base;

namespace Product.Persistence.Base
{
	public interface IQueryRepository<T> where T :IEntity
	{
		Task<T> GetByIdAsync(System.Guid id);

		Task<IList<T>> GetAllAsync();
	}
}
