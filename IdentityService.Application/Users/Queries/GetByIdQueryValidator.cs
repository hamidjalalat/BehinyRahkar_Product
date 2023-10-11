using FluentValidation;

namespace Product.Application.Users.Queries
{
	public class GetByIdQueryValidator :
		FluentValidation.AbstractValidator<GetByIdQuery>
	{
		public GetByIdQueryValidator() : base()
		{
			RuleFor(current => current.Id)
				.NotEmpty()
				.WithMessage(errorMessage: "Count is required!")

				;
		}
	}
}
