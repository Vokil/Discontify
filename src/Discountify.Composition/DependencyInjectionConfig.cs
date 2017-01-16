namespace Discountify.Composition
{
    using Core.Audit;
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

        public static void Initialize(IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            config = configurationRoot;

            RegisterDbContext(services);
            RegisterServices(services);
            RegisterRepositories(services);
            RegisterClaimsProvider(services);
            RegisterAuditProvider(services);
        }

        private static void RegisterDbContext(IServiceCollection services)
        {
            services.AddScoped<IDiscountifyContext, DiscountifyContext>();

            services.AddDbContext<DiscountifyContext>(options => options.UseSqlServer(config.GetConnectionString(DISCOUNTIFY_CONNECTION_NAME),
                opt => opt.EnableRetryOnFailure()));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
        }

        private static void RegisterClaimsProvider(IServiceCollection services)
        {
            services.AddScoped<IClaimsPrincipleProvider, ClaimsPrincipleProvider>();
        }

        private static void RegisterAuditProvider(IServiceCollection services)
        {
            services.AddScoped<IAuditProvider, AspNetAuditProvider>();
        }
    }
}
