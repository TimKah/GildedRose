using GildedRose.Domain.Abstractions;
using GildedRose.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GildedRose.Controllers
{
    public class ShopController : IShopController
    {
        IShopService _shopService;

        public List<Item> Items { get; private set; }

        public ShopController(IShopRepository shopRepository, IShopService shopService)
        {
            _shopService = shopService;
            GetItemsAsync(shopRepository).Wait();
        }

        private async Task GetItemsAsync(IShopRepository shopRepository)
        {
            Items = await shopRepository.GetItemsAsync();
        }

        public void SimulateDay()
        {
            Parallel.ForEach(Items, item =>
            {
                _shopService.SimulateDay(ref item);
            });
        }
    }
}
