using GildedRose.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GildedRose.Domain.Abstractions
{
    public interface IShopRepository
    {
        public Task<List<Item>> GetItemsAsync();
    }
}
