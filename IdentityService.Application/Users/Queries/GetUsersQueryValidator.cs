using FluentValidation;

namespace Product.Application.Users.Queries
{
	public class GetUsersQueryValidator :
		FluentValidation.AbstractValidator<GetUsersQuery>
	{
		public GetUsersQueryValidator() : base()
		{
			RuleFor(current => current.Count)
				.NotEmpty()
				.WithMessage(errorMessage: "Count is required!")

				;
		}
	}
}
