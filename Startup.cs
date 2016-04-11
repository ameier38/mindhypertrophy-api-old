using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MindHypertrophy.Models;

namespace MindHypertrophy
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();     //overwrites DefaultConnection when published to Azure
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddMvc();

            //Add entity framework services
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>();

            //Add CORS to enable cross orgin requests
            services.AddCors();

            //Add interface to services
            services.AddScoped<IAppRepository, AppRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug(LogLevel.Error);
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();

            //Add allows cors orgins
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:3000")
            );
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
