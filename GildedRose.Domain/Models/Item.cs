using GildedRose.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Domain.Models
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public ItemType ItemType { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
