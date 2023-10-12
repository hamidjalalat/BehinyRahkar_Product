namespace Product.Persistence.ViewModels
{
	public class GetProductsQueryResponseViewModel 
	{
		public GetProductsQueryResponseViewModel() : base()
		{
		}

		 
		public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Categories { get; set; }

        public double Price { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


    }
}
