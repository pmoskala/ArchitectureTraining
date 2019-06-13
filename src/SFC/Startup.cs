using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SFC.AdminApi;
using SFC.UserApi;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace SFC
{
    public class Startup
    {
        public static Action<ContainerBuilder> RegisterExternalTypes { get; set; } = builder => { };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
              .AddMvc(opt =>
              {
                  // Enable fluent validation
                  // opt.Filters.Add(typeof(FluentValidationActionFilter));
              })
              .AddApplicationPart(typeof(AutofacUserApiModule).Assembly)
              .AddApplicationPart(typeof(AutofacAdminApiModule).Assembly)
              .AddControllersAsServices()
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Enable fluent validation
            //.AddFluentValidation(fvc =>
            //{
            //  fvc.RegisterValidatorsFromAssemblyContaining<AutofacUserApiModule>();
            //  fvc.RegisterValidatorsFromAssemblyContaining<AutofacAdminApiModule>();
            //});

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder
            .AddConsole()
            .AddConfiguration(Configuration.GetSection("logging"))
            .AddDebug();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SmogFightClub API", Version = "v1" });
            });

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Ioc
            var builder = new ContainerBuilder();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            builder.RegisterModule(new MainModule(connectionString));
            RegisterExternalTypes(builder);

            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NicePress Api v1");
            });
            app.UseMvc();
        }
    }
}
