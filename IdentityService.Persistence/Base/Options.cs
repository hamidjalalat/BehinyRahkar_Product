using Product.Base;
using Product.Base.Enums;

namespace Product.Persistence.Base
{
	public class Options : object
	{
		public Options() : base()
		{
		}

		public Provider Provider { get; set; }

		public string ConnectionString { get; set; }

		public string InMemoryDatabaseName { get; set; }
	}
}
