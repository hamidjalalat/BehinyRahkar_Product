using Product.Domain.Models;
using Product.Persistence.ViewModels;

namespace Product.Persistence.Users.Repositories
{
	public interface IUserQueryRepository : Product.Persistence.Base.IQueryRepository<User>
	{
		Task
			<IList<GetUsersQueryResponseViewModel>>
			GetSomeAsync(int count);

		Task<GetUsersQueryResponseViewModel> GetByUserNameAsync(String username);
     
    }
}
