using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Warehouse.Configuration.FileUpload;
using Warehouse.Core;
using Warehouse.Core.Repositories;
using Warehouse.Persistence;
using Warehouse.Persistence.Repositories;
using Warehouse.Services;

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

            services.Configure<FileSettings>(_configuration.GetSection("FileSettings"));

            services.AddAutoMapper();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(_configuration.GetConnectionString("Default")));

            services.AddScoped<OrderService>();
            services.AddScoped<FileSystemPhotoOperations>();
            services.AddScoped<MerchantService>();
            services.AddScoped<ProductService>();
            services.AddScoped<SupplyOperations>();
            services.AddScoped<TechnicianService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();
            services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();
            services.AddScoped<ITechnicianPhotoRepository, TechnicianPhotoRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(DefaultCorsPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
