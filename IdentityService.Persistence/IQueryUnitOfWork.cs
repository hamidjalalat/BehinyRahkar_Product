using Product.Persistence.Repositories;
using Product.Persistence.Users.Repositories;

namespace Product.Persistence
{
    public interface IQueryUnitOfWork : Product.Persistence.Base.IQueryUnitOfWork
    {
        public IUserQueryRepository Users { get; }
        public IProductQueryRepository Products { get; }
    }
}
