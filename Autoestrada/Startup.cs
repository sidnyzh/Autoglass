using Autoestrada.Application.DTO;
using Autoestrada.Application.Interface;
using Autoestrada.Application.Main;
using Autoestrada.Domain.Core;
using Autoestrada.Domain.Entity.Entities;
using Autoestrada.Domain.Entity.Validations;
using Autoestrada.Domain.Interface;
using Autoestrada.Repository.Interface;
using Autoestrada.Services.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Autoestrada.Repository.Pattern;

namespace Autoestrada
{
    public class Startup
    {
        readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Swagger
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Autoestrada", Version = "v1" });
            });
            #endregion

            #region DB Connection
            services.AddDbContext<AutoestradaContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("AutoestradaMySql"), new MySqlServerVersion(new Version()));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            #endregion

            #region Configuring HandleException error model
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errorDetails = context.ConstructErrorMessages();
                    return new BadRequestObjectResult(errorDetails);
                };
            });
            #endregion

            #region Adding Automapper
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            #endregion

            #region FluentValidation
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            #endregion
            services.AddScoped<IProveedorApplication, ProveedorApplication>();
            services.AddScoped<IProveedorDomain, ProveedorDomain>();
            services.AddScoped<IRepository<Proveedor>, Repository<Proveedor>>();
            services.AddTransient<IValidator<Proveedor>, ProveedorValidator>();

            services.AddScoped<IProductoApplication, ProductoApplication>();
            services.AddScoped<IProductoDomain, ProductoDomain>();
            services.AddScoped<IRepository<Producto>, Repository<Producto>>();
            services.AddTransient<IValidator<Producto>, ProductoValidator>();
            services.AddTransient<IValidator<ProductoDTO>, ProductoDTOValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autoestrada v1"));
            }

            app.UseExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
