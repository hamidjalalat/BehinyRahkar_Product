namespace Product.Application.Products.Commands
{

    public class CreateProductCommand : Mediator.IRequest<Guid>
    {
        public CreateProductCommand() : base()
        {
        }

        public string Name { get; set; }

        public string Categories { get; set; }

        public string Price { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


    }
}
