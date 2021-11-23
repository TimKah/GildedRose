using GildedRose.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Controllers.Registration.Extensions
{
    public static class ShopControllerExtension
    {
        public static IServiceCollection AddShopController(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IShopController, ShopController>();
        }
    }
}
