using FluentValidation;

namespace Product.Application.Products.Commands
{
    public class CreateProductCommandValidator :
        AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() : base()
        {
            RuleFor(current => current.Name)
                .NotEmpty()
                .WithMessage(errorMessage: "Requred");

            RuleFor(current => current.Title)
             .NotEmpty()
             .WithMessage(errorMessage: "Requred");

            RuleFor(current => current.Categories)
             .NotEmpty()
             .WithMessage(errorMessage: "Requred");
        }
    }
}
