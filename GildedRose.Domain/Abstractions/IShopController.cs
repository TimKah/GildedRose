using GildedRose.Domain.Models;
using System.Collections.Generic;

namespace GildedRose.Domain.Abstractions
{
    public interface IShopController
    {
        public List<Item> Items { get; }

        public void SimulateDay();
    }
}
