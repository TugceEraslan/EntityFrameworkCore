using EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));  // UseSqlServer ý kullanabilmem için nuget ten  Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.3 i indirdim.
            });
            services.AddTransient<IProductRepository, EfProductRepository>(); // Uygulama içerisinde IProductRepository çaðýrdýðým zaman EfProductRepository den de bir örnek gönder. 
            // AddTransient: Her servis isteðinde yeni bir instance oluþturulur.Transient servisinden üretilir.
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                     
            app.UseStaticFiles();    // wwwrooot klasörüne eriþememiz için
            app.UseStatusCodePages();  // 404 hatasý gibi sayfalarýn statüsünü görürürüz
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseMvc(routes =>
            {
                Microsoft.AspNetCore.Routing.IRouteBuilder routeBuilder = routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });



        }
    }
}
