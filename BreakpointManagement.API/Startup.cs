using BreakpointManagement.Data;
using BreakpointManagement.Data.Context;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakpointManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string CORSPolicy = "CORSPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BreakpointManagementDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BreakpointManagementConnection")));

            services.AddScoped<IBreakpointManagementRepository, BreakpointManagementRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSPolicy,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44311", "https://localhost:44379")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BreakpointManagement.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(BreakpointManagementProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BreakpointManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CORSPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
