namespace Discountify.Identity
{
    using Composition;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Settings;

    public class Startup
    {
        private readonly IHostingEnvironment environment;

        public Startup(IHostingEnvironment env)
        {
            this.environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureIdentity(services);
            this.ConfigureIdentityServer(services);

            DependencyInjectionConfig.Initialize(services, this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug();
            app.UseDeveloperExceptionPage();

            app.UseIdentity();
            app.UseIdentityServer();
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DiscountifyContext>()
                .AddDefaultTokenProviders();
        }

        private void ConfigureIdentityServer(IServiceCollection services)
        {
            services.Configure<IdentityApiResourcesSettings>(this.Configuration.GetSection("IdentityApiResources"));
            services.Configure<IdentityClientsSettings>(this.Configuration.GetSection("IdentityClients"));

            var apiResourceSettingsCollection = services
                .BuildServiceProvider()
                .GetService<IOptions<IdentityApiResourcesSettings>>();

            var clientsSettingsCollection = services
                .BuildServiceProvider()
                .GetService<IOptions<IdentityClientsSettings>>();

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources(apiResourceSettingsCollection?.Value?.Collection))
                .AddInMemoryClients(Config.GetClients(clientsSettingsCollection?.Value?.Collection))
                .AddAspNetIdentity<User>();
        }
    }
}
