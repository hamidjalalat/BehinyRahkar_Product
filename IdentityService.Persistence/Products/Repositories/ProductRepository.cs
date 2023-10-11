
using Microsoft.EntityFrameworkCore;

namespace Product.Persistence.Products.Repositories
{
	public class ProductRepository :
        Product.Persistence.Base.Repository<Product.Domain.Models.Product>, IProductRepository
	{
		protected internal ProductRepository
            (DbContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
