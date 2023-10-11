﻿using Product.Persistence.ViewModels;

namespace Product.Application.Users.Queries
{
	public class GetUsersQuery : object,
		Mediator.IRequest
		<System.Collections.Generic.IEnumerable<GetUsersQueryResponseViewModel>>
	{
		public GetUsersQuery() : base()
		{
		}

		public int? Count { get; set; }
	}
}
