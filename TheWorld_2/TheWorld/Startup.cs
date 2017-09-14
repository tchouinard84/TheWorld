using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Services;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            //create ONE instance the first time and use over and over
            //services.AddSingleton<IMailService, DebugMailService>();

            //supply an interface which can be fulfilled by a certain class, it will create an instance of DebugMailService as it needs it (may be cached)
            //services.AddTransient<IMailService, DebugMailService>();

            if (_env.IsEnvironment("Development") || _env.IsEnvironment("Testing"))
            {
                services.AddScoped<IMailService, DebugMailService>();       //creates an instance of DebugMailService for each request
            }
            else
            {
                // Implement a real Mail Service
            }

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsEnvironment("Development"))
            {
                // This is nice for development, but don't want to show to the end user
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();  // If index.html exists, use it
            app.UseStaticFiles();   // I will deliver any file that lives in wwwroot folder

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                );
            });

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<html><body><h2>Hello World!</h2></body></html>");
            });
            */
        }
    }
}
