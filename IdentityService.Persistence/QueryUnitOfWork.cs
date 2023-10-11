using Product.Persistence.Repositories;
using Product.Persistence.Users.Repositories;

namespace Product.Persistence
{
	public class QueryUnitOfWork :
        Product.Persistence.Base.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
	{
		public QueryUnitOfWork
			(Product.Persistence.Base.Options options) : base(options: options)
		{
		}

		private IUserQueryRepository _users;

		public IUserQueryRepository Users
		{
			get
			{
				if (_users == null)
				{
                    _users =
						new Users.Repositories.UserQueryRepository(databaseContext: DatabaseContext);
				}

				return _users;
			}
		}

        private IProductQueryRepository _products;

        public IProductQueryRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products =
                        new Products.Repositories.ProductQueryRepository(databaseContext: DatabaseContext);
                }

                return _products;
            }
        }
    }
}
