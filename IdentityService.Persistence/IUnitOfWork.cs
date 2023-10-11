using Product.Persistence.Products.Repositories;
using Product.Persistence.Users.Repositories;

namespace Product.Persistence
{
    public interface IUnitOfWork : Product.Persistence.Base.IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IProductRepository Products { get; }
    }
}
