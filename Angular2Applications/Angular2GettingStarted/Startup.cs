using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Angular2GettingStarted.Services;
using System;
using Microsoft.AspNetCore.Routing;

namespace Angular2GettingStarted
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //there are default registrations 
            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // app.UseDefaultFiles();
            // app.UseStaticFiles();
            // Equivalent to the following 
            app.UseFileServer();

            app.UseMvc(configureRoute);

            app.Run(async (context) =>
            {
                var greeting = greeter.GetGreeting();

                await context.Response.WriteAsync(greeting);
            });
        }

        private void configureRoute(IRouteBuilder routeBuilder)
        {
            // /
            // Home/Index/1

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
