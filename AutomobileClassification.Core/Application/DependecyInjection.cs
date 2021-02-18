using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AutomobileClassification.Core.Application.Services.Posts;
using AutomobileClassification.Core.Application.Services.CategoriesModels;
using AutomobileClassification.Core.Application.Common.Interface;
using System.Reflection;

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
            return services;
        }
    }
}