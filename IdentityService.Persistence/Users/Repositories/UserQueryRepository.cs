using System.Linq;
using Product.Domain.Models;
using Product.Persistence.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Product.Persistence.Users.Repositories
{
	public class UserQueryRepository :
        Product.Persistence.Base.QueryRepository<User>, IUserQueryRepository
	{
		public UserQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public
			async
			Task
			<IList<GetUsersQueryResponseViewModel>>
			GetSomeAsync(int count)
		{

			var result =
				await
				DbSet
			
				.Select(current => new ViewModels.GetUsersQueryResponseViewModel()
				{
					Id = current.Id,
					UserName=current.UserName,
					FirstName=current.FirstName,
					LastName=current.LastName,
					EmailAddress=current.EmailAddress,
					Password=current.Password,
				})
				.ToListAsync()
				;


			return result;
		}

        //موقت تا زمانی که بانک اطلاعاتی راه بندازم
        public async Task<GetUsersQueryResponseViewModel> GetByUserNameAsync(String username)
        {
			var result =
			await
			DbSet.Where(C => C.UserName == username).
			Select(current => new ViewModels.GetUsersQueryResponseViewModel()
			{
				UserName = current.UserName,
				FirstName = current.FirstName,
				LastName = current.LastName,
				EmailAddress=current.EmailAddress,

			})
            .FirstOrDefaultAsync();

            return result;
        }
    }
}
