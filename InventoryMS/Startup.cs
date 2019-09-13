using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMS.DAL;
using InventoryMS.Helper;
using InventoryMS.Services.Master;
using InventoryMS.Services.Master.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Database Settings
            services.AddDbContextPool<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            #endregion
            #region Master services
            services.AddScoped<ICatagoryService, CatagoryService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IThanaService, ThanaService>();
            services.AddScoped<ISupplierService, SupplierService>();
          
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductStockDetailsService, ProductStockDetailsService>();
            services.AddScoped<IProductStockService,ProductStockService>();
            services.AddScoped<IPersonnelInfoService, PersonnelInfoService>();
            services.AddScoped<IProductSalesDetailsService, ProductSalesDetailsService>();
            services.AddScoped<IProductSaleMasterService, ProductSaleMasterService>();
            #endregion

            #region helper
            services.AddScoped<IHelperService, HelperService>();
            #endregion
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
