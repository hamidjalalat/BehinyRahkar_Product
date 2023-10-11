using Product.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Persistence.Users.Repositories
{
	public class UserRepository :
        Product.Persistence.Base.Repository<User>, IUserRepository
	{
		protected internal UserRepository
			(DbContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
