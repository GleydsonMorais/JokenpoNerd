using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokenpoNerd.API.Interfaces;
using JokenpoNerd.API.Services;
using JokenpoNerd.Data.Context;
using JokenpoNerd.Data.Repositories;
using JokenpoNerd.Data.Repositories.Logs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace JokenpoNerd.API
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
            services.AddDbContext<JokenpoNerdContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            //Inject Services
            services.AddTransient<IJokenpoNerdService, JokenpoNerdService>();

            //Inject Repositories
            services.AddTransient<IJokenpoNerdRepository, JokenpoNerdRepository>();
            services.AddTransient<ILogRepository, LogRepository>();

            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Jokenpô versão Nerd",
                    Version = "v1",
                    Description = "API REST criada com o ASP.NET Core 3.1 para o Jogo Jokenpô versão Nerd"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Jokenpô versão Nerd V1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
