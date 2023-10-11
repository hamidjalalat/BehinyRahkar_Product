using FluentValidation;

namespace Product.Application.Users.Queries
{
	public class GetByUserNameQueryValidator :
		FluentValidation.AbstractValidator<GetByUserNameQuery>
	{
		public GetByUserNameQueryValidator() : base()
		{
			RuleFor(current => current.UserName)
				.NotEmpty()
				.WithMessage(errorMessage: "Count is required!")
				;

			RuleFor(current => current.Password)
				.NotEmpty()
				.WithMessage(errorMessage: "Count is required!");

        }
	}
}
