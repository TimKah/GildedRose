using GildedRose.Domain.Models;

namespace GildedRose.Domain.Abstractions
{
    public interface IShopService
    {
        public void SimulateDay(ref Item item);
    }
}
