using FluentValidation;

namespace Product.Application.Products.Queries
{
	public class GetProductsQueryValidator :
		FluentValidation.AbstractValidator<GetProductsQuery>
	{
		public GetProductsQueryValidator() : base()
		{
			RuleFor(current => current.Count)
				.NotEmpty()
				.WithMessage(errorMessage: "Count is required!")

				;
		}
	}
}
