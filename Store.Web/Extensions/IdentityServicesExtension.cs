using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.BasketService.Dtos;
using Store.Service.Services.BasketService;
using Store.Service.Services.CacheService;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;
using Store.Data.Entity.IdentityEntity;
using Microsoft.AspNetCore.Identity;
using Store.Data.Context;

namespace Store.Web.Extensions
{
    public static class IdentityServicesExtension
    {

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();
            builder.AddSignInManager<AppUser>();
            services.AddAuthentication();
            return services;
        }





    }
}
