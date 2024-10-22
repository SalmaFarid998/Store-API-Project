﻿using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;

namespace Store.Web.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(ProductProfile));

            //builder.Services.Configure<CustomException>(Options => 
            //{
            //    Options.InvalidModelStateResponseFactory
            //}

            //)
            return services;
        }
    }
}
