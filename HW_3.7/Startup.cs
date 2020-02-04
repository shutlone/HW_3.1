using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace HW_3._7
{
    public interface IMessageSender
    {
        string Send();
    }

    public class MessageService
    {
        IMessageSender s;
        public MessageService(IMessageSender sender)
        {
            s = sender;
        }
        public string Send()
        {
            return s.Send();
        }
    }

    //public class SmsMessageSender : IMessageSender
    //{
    //    private string text;
    //    public SmsMessageSender(HttpContext context)
    //    {
    //        text = context.Request.Cookies["text"];
    //        if (text.Length != 0)
    //        {
    //            context.Response.Cookies.Append("text", "Тут лежит текст");
    //        }
    //    }

    //    public string Send()
    //    {
    //        if (text.Length != 0)
    //        {
    //            return "text empty";
    //        }
    //        return text;
    //    }
    //}



    public class EmailMessageSender : IMessageSender
    {
        private string text;
        public EmailMessageSender(HttpContext context)
        {
            text = context.Session.GetString("text");
            if (text == null)
            {
                context.Session.SetString("text", "Тут текст");
            }
        }
        public string Send()
        {
            if (text == null)
            {
                return "text empty";
            }
            return text;
        }
    }
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
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            app.Map("/Email", Email);
            //app.Map("/SMS", SMS);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void Email(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var m = new MessageService(new EmailMessageSender(context));
                await context.Response.WriteAsync(m.Send());
            });
        }

        //private void SMS(IApplicationBuilder app)
        //{
        //    app.Run(async (context) =>
        //    {
        //        var m = new MessageService(new SmsMessageSender(context));
        //        await context.Response.WriteAsync(m.Send());
        //    });
        //}
    }
}
