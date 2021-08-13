using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Warehouse.GraphQL;
using Warehouse.GraphQL.Types;
using Warehouse.Services.Photo;
using Warehouse.Persistence;

namespace Warehouse
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private const string DefaultCorsPolicy = "DefaultCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicy, builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.WithMethods("POST", "GET", "DELETE", "PUT");
                });
            });

            services
                .AddGraphQLServer()
                .ModifyRequestOptions(options => options.IncludeExceptionDetails = true)
                .AddQueryType<Query>()
                .AddType<OrderDetailType>()
                .AddType<OrderType>()
                .AddType<ProductPhotoType>()
                .AddType<ProductType>()
                .AddType<StockType>()
                .AddType<StockEntryType>()
                .AddType<SupplierType>()
                .AddType<TechnicianBalanceEntryType>()
                .AddType<TechnicianPhotoType>()
                .AddType<TechnicianType>();

            services.Configure<FileSettings>(_configuration.GetSection("FileSettings"));

            services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
                options.UseMySQL(_configuration.GetValue<string>("ConnectionStrings:Default")));

            services.AddScoped<FileSystemPhotoStorage>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(DefaultCorsPolicy);

            app.UseEndpoints(endpoints => endpoints.MapGraphQL());

            app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager"
            });
        }
    }
}
