using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Products.Commands;

namespace Product.Core
{
	public static class DependencyContainer 
	{
		static DependencyContainer()
		{
		}

		public static void ConfigureServices
			(Microsoft.Extensions.Configuration.IConfiguration configuration,
			Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddTransient
				<Microsoft.AspNetCore.Http.IHttpContextAccessor,
				Microsoft.AspNetCore.Http.HttpContextAccessor>();

		

			// AddMediatR -> Extension Method -> using MediatR;
			// GetTypeInfo -> Extension Method -> using System.Reflection;
			services.AddMediatR
				(typeof(Product.Application.Users.MappingProfile).GetTypeInfo().Assembly);

			// AddValidatorsFromAssembly -> Extension Method -> using FluentValidation;
			services.AddValidatorsFromAssembly
				(assembly: typeof(CreateProductCommandValidator).Assembly);

			services.AddTransient
				(typeof(MediatR.IPipelineBehavior<,>), typeof(Mediator.ValidationBehavior<,>));

			// using Microsoft.Extensions.DependencyInjection;
			services.AddAutoMapper
				(profileAssemblyMarkerTypes: typeof(Product.Application.Users.MappingProfile));

			services.AddTransient<Product.Persistence.IUnitOfWork, Product.Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "CommandsDatabaseProvider")
					.Value;

                Product.Base.Enums.Provider databaseProvider =
					(Product.Base.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                Product.Persistence.Base.Options options =
					new Product.Persistence.Base.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Product.Persistence.UnitOfWork(options: options);
			});

			services.AddTransient<Product.Persistence.IQueryUnitOfWork, Product.Persistence.QueryUnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "QueriesConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "QueriesDatabaseProvider")
					.Value;

                Product.Base.Enums.Provider databaseProvider =
					(Product.Base.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                Product.Persistence.Base.Options options =
					new Product.Persistence.Base.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Product.Persistence.QueryUnitOfWork(options: options);
			});
		}
	}
}
