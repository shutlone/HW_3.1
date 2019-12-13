using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HW_3._3
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/formula1", form1);
            app.Map("/formula2", form2);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found");
            });
        }

        private static void form1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                double x = 3;
                double y = 7;
                double z = 0;

                z = Math.Pow(2, x) * Math.Pow(3, y) * Math.Pow(4, Math.Sin(1 / (x + 2)));

                await context.Response.WriteAsync($"2^{x} * 3^{y} * 4^( sin( 1 / ({x} + 2) ) ) = {z}");
            });
        }
        private static void form2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                double x = 3;
                double y = 7;
                double z = 0;

                z = Math.Pow(Math.Cos(x), 2) + Math.Pow(Math.Sin(x), 2) - Math.Sqrt(Math.Pow(3 , x + 2 ));

                await context.Response.WriteAsync($"cos({x})^2 + sin({x})^2 - sqrt( 3^({y} + 2) ) = {z}");
            });
        }
    }
}
