using System.Reflection;
using Krystal.Services.Admin.Business;
using Krystal.Services.Admin.Business.Repositories;
using Krystal.Services.Admin.Database;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Krystal.Services.Admin
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var type = Configuration["Database"];

            switch(type)
            {
                case "Memory":
                    services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(Configuration["Endpoint"]));
                    break;

                case "SQLServer":
                    services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["Endpoint"]));
                    break;

                case "SQLite":
                    services.AddDbContext<DatabaseContext>(options => options.UseSqlite(Configuration["Endpoint"]));
                    break;
            }

            services.AddTransient<ILinkRepository, LinkRepository>();

            services.AddMediatR(typeof(Handler).Assembly);

            services.AddSwaggerGen(cfg => cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "Krystal Admin API", Version = "v1" }));

            services.AddCors(cfg => cfg.AddDefaultPolicy(new CorsPolicy
            {
                ExposedHeaders = { "*" },
                Headers = { "*" },
                Methods = { "*" },
                Origins = { "*" }
            }));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(cfg => cfg.SwaggerEndpoint("v1/swagger.json", "Krystal Admin API v1"));

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}