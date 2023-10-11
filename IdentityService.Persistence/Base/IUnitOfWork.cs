namespace Product.Persistence.Base
{
	public interface IUnitOfWork : IQueryUnitOfWork
	{
		Task SaveAsync();
	}
}
