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
            services.AddTransient<IProductRepository, FakeProductRepository>(); // Uygulama i�erisinde IProductRepository �a��rd���m zaman FakeProductRepository den de bir �rnek g�nder. 
            // AddTransient: Her servis iste�inde yeni bir instance olu�turulur.Transient servisinden �retilir.
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
                     
            app.UseStaticFiles();    // wwwrooot klas�r�ne eri�ememiz i�in
            app.UseStatusCodePages();  // 404 hatas� gibi sayfalar�n stat�s�n� g�r�r�r�z
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
