using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PersistanceLayer.Context;
using ServiceLayer.Contracts;
using ServiceLayer.Services;

namespace IAEW_LogisticOperator_Center_API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}/";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:Audience"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("write::envios", policy => policy.Requirements.Add(new HasScopeRequirement("write::envios", domain)));
                options.AddPolicy("write::repartidores", policy => policy.Requirements.Add(new HasScopeRequirement("write::repartidores", domain)));
                options.AddPolicy("write::estados_envios", policy => policy.Requirements.Add(new HasScopeRequirement("write::estados_envios", domain)));
            });

            services.AddControllers();

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            services.AddTransient<IRepartidoresService, RepartidoresService>();
            services.AddTransient<IOrdenesService, OrdenesService>();


            services.AddDbContext<LogisticOperatorDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"API Operador logístico centro {groupName}",
                    Version = groupName,
                    Description = "Documentación de la API del operador logístico centro, para el trabajo práctico integrador de la materia 'Integración de Aplicaciones Web', UTN FRC 2021",
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IAEW API V1");
            });
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}