namespace Product.Persistence.Base
{
	public interface IQueryUnitOfWork : IDisposable
	{
		bool IsDisposed { get; }
	}
}
