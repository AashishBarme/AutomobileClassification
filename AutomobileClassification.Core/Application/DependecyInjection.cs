using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutomobileClassification.Core.Application.Services.Posts;
using AutomobileClassification.Core.Application.Services.CategoriesModels;
using AutomobileClassification.Core.Application.Common.Interface;
using System.Reflection;
using AutomobileClassification.Core.Application.Services.Users;
using AutomobileClassification.Core.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace AutomobileClassification.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICategoryModelService, CategoryModelService>();
            services.AddTransient<IUsersService,UsersService>();
            services.AddTransient<IdentityService>();
            return services;
        }

         public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = new JwtConfig(configuration["Jwt:Key"], configuration["Jwt:Issuer"]);
            JwtTokenService tokenService = new JwtTokenService(jwtConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Issuer,
                    IssuerSigningKey = tokenService.GetSymmetricSecurityKey()
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            services.AddSingleton(tokenService);
            return services;
        }
    }
}