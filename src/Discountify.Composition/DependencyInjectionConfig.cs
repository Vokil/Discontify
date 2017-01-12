namespace Discountify.Composition
{
    using Data;
    using Data.Repositories;
    using Data.Repositories.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Contracts;

    public static class DependencyInjectionConfig
    {
        private const string DISCOUNTIFY_CONNECTION_NAME = "DiscountifyContextConnection";
        private static IConfigurationRoot config;

        public static void Initialize(IServiceCollection serviceCollection, IConfigurationRoot configurationRoot)
        {
            config = configurationRoot;

            RegisterDbContext(serviceCollection);
            RegisterServices(serviceCollection);
            RegisterRepositories(serviceCollection);
        }

        private static void RegisterDbContext(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDiscountifyContext, DiscountifyContext>();

            serviceCollection.AddDbContext<DiscountifyContext>(options => options.UseSqlServer(config.GetConnectionString(DISCOUNTIFY_CONNECTION_NAME)));
        }

        private static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICardService, CardService>();
        }

        private static void RegisterRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICardRepository, CardRepository>();
        }
    }
}
