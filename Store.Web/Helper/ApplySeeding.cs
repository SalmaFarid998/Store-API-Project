﻿using Store.Data.Context;
using Store.Repository;

namespace Store.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = service.GetRequiredService<StoreDBContext>();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
