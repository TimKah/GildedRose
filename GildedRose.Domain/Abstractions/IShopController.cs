using GildedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Domain.Abstractions
{
    public interface IShopController
    {
        public List<Item> Items { get; }

        public void SimulateDay();
    }
}
