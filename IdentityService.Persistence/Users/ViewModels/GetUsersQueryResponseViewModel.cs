namespace Product.Persistence.ViewModels
{
	public class GetUsersQueryResponseViewModel : object
	{
		public GetUsersQueryResponseViewModel() : base()
		{
		}

		 
		public System.Guid Id { get; set; }

        public string UserName { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Services { get; set; }

        public string Role { get; set; }

        public string Message { get; set; }
		 
	}
}
