using System.Linq;

using Product.Persistence.ViewModels;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Repositories;

namespace Product.Persistence.Products.Repositories
{
	public class ProductQueryRepository :
        Product.Persistence.Base.QueryRepository<Product.Domain.Models.Product>, IProductQueryRepository
	{
		public ProductQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
		{
		}

        public async Task
        <IList<GetProductsQueryResponseViewModel>>
        GetSomeAsync(int count)
        {
            var result =
                await
                DbSet
                .OrderByDescending(current => current.Name)
                .Skip(count: 0)
                .Take(count: count)
                .Select(current => new GetProductsQueryResponseViewModel()
                {
                    Id = current.Id,
                    Name = current.Name,
                    Categories = current.Categories,
                    Description = current.Description,
                    Price = current.Price,
                    Title = current.Title,
                })
                .ToListAsync()
                ;

            return result;
        }
    }
}
