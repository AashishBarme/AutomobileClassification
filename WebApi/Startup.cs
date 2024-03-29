using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutomobileClassification.Core.Application;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Infrastructure;
using AutomobileClassification.Core.Infrastructure.Persistence;
using System.Text;
using System.Threading.Tasks;


using Microsoft.OpenApi.Models;
using System;
using AutomobileClassification.Core.Infrastructure.Identity;
using Microsoft.Extensions.ML;
using ImageClassification.DataModels;

namespace WebApi
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
            services.AddApplication(Configuration);
            services.AddControllers();
            var mysqlSettings = Configuration.GetSection("MysqlVersion");
            services.AddDbContext<AppDbContext>(
                option =>{
                    var serverVersion = new Version(10,1,47);
                option.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion (serverVersion));
                    
                }
            );
             services.AddIdentity<ApplicationUser, IdentityRole<long>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Lockout.AllowedForNewUsers = false;

            }).AddSignInManager().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
             services.AddJwtAuthentication(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

             services.AddCors(c => c.AddPolicy("CorsPolicy", policy =>
            {
                policy.WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader().AllowCredentials();
            }));

            services.AddDirectoryBrowser();

            /////////////////////////////////////////////////////////////////////////////
            // Register the PredictionEnginePool as a service in the IoC container for DI.
            //
            services.AddPredictionEnginePool<InMemoryImageData, ImagePrediction>()
                    .FromFile(Configuration["MLModel:MLModelFilePath"]);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
