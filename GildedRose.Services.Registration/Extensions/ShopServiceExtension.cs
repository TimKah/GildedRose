using GildedRose.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Services.Registration.Extensions
{
    public static class ShopServiceExtension
    {
        public static IServiceCollection AddShopService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IShopService, ShopService>();
        }
    }
}
