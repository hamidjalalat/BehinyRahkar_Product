using Product.Persistence.Products.Repositories;
using Product.Persistence.Users.Repositories;

namespace Product.Persistence
{
	public class UnitOfWork :
        Product.Persistence.Base.UnitOfWork<DatabaseContext>, IUnitOfWork
	{
		public UnitOfWork
			(Product.Persistence.Base.Options options) : base(options: options)
		{
		}

        private IUserRepository _users;

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users =
                        new Users.Repositories.UserRepository(databaseContext: DatabaseContext);
                }

                return _users;
            }
        }
        private IProductRepository _products;

        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products =
                        new ProductRepository(databaseContext: DatabaseContext);
                }

                return _products;
            }
        }

    }
}
