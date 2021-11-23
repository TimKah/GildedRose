using GildedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Domain.Abstractions
{
    public interface IShopService
    {
        public void SimulateDay(ref Item item);
    }
}
