using GildedRose.Database.Repositories;
using GildedRose.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.Database.Registration.Extensions
{
    public static class ShopRepositoryExtension
    {
        public static IServiceCollection AddShopRepository(this IServiceCollection serviceCollection, string itemsPath, string itemTypesPath)
        {
            return serviceCollection.AddSingleton<IShopRepository>(new ShopRepository(itemsPath, itemTypesPath));
        }
    }
}
