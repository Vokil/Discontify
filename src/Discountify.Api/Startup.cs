namespace Discountify.Api
{
    using Composition;
    using Data;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Settings;
    using System.Net;
    using System.Threading.Tasks;

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

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(this.Configuration);

            services.Configure<IdentityServerSettings>(this.Configuration.GetSection("IdentityServer"));

            this.ConfigureMvc(services);
            this.ConfigureIdentity(services);

            DependencyInjectionConfig.Initialize(services, this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<IdentityServerSettings> identityServerOptions)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApplicationInsightsRequestTelemetry();
            app.UseApplicationInsightsExceptionTelemetry();

            app.UseIdentity();

            this.UseIdentityServer(app, identityServerOptions);

            app.UseMvcWithDefaultRoute();
        }


        private void ConfigureMvc(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                if (this.environment.IsProduction())
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            });
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.Password = new PasswordOptions
                {
                    RequireDigit = false,
                    RequiredLength = 4,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false
                };

                config.User = new UserOptions
                {
                    RequireUniqueEmail = false,
                };

                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = async ctx =>
                    {
                        ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                        await Task.Yield();
                    }
                };
            })
            .AddEntityFrameworkStores<DiscountifyContext>();
        }

        private void UseIdentityServer(IApplicationBuilder app, IOptions<IdentityServerSettings> identityServerOptions)
        {
            var identityServerAuthOptions = new IdentityServerAuthenticationOptions
            {
                Authority = identityServerOptions.Value.Authority,
                RequireHttpsMetadata = identityServerOptions.Value.RequireHttpsMetadata,
                ApiName = identityServerOptions.Value.ApiName
            };

            app.UseIdentityServerAuthentication(identityServerAuthOptions);
        }
    }
}
