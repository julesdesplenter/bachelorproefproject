using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Azure.Storage.Blobs;
using ECommerce.API.Services;
using Microsoft.OpenApi.Models;

namespace musicAPI
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://laptopjules:8863",
                    ValidAudience = "http://laptopjules",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Musicprojectdinkkeynoglangermisschien"))
                };
                options.SaveToken = false; 
                options.RequireHttpsMetadata = false;
            });
            services.AddSingleton(x => new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=musicproject;AccountKey=EyhQqE4kQ3Raiy0zfALubpRtWuBoUoSJm0j6dKnGid82RVdhDDWUvhSg8hxIfgbBxZlQc5m90I/OjYshBFS/wA==;EndpointSuffix=core.windows.net"));
            services.AddSingleton<IBlobService, BlobService>();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "musicAPI", Version = "v1.0" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("MyAllowOrigins");

            app.UseCors(cfg =>
            {
                cfg.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin();
            });

            app.UseSwagger(); 
            app.UseSwaggerUI(c => 
            { 
                c.RoutePrefix = "swagger"; 
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "ToDo_API v1.0"); 
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
