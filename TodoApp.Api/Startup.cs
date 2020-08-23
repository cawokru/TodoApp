using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoApp.Application;
using TodoApp.Common.Web.Filters;
using TodoApp.DataAccess;

namespace TodoApp.Api
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
            services.AddApplication();

            //TODO: Review project dependencies for EF
            services.AddDataAccess(opt => {
                opt.ConnectionString = Configuration["ConnectionStrings:DefaultConnection"]; // TODO: Replace with env variable
            });

            services.AddControllers(options =>
                options.Filters.Add(typeof(ApiExceptionFilterAttribute)));

            services.AddOpenApiDocument(opt =>
                opt.Title = "TodoApp Api");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // serve basic Swagger
                app.UseOpenApi();
                app.UseSwaggerUi3();
                app.UseReDoc();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            services.SeedDatabase();
        }
    }
}
