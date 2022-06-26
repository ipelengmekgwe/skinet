using Core.Interfaces;
using DataAccess.Data;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SkiNet.API.Errors;
using System.Linq;

namespace SkiNet.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors)
                        .Select(e => e.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationResponse { Errors = errors };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
