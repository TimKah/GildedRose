using GildedRose.Domain.Abstractions;
using GildedRose.Domain.Models;
using System;

namespace GildedRose.Services
{
    public class ShopService : IShopService
    {
        public void SimulateDay(ref Item item)
        {
            if (item.ItemType.SpecialFlags.Contains("LEGENDARY")) return;

            int qualityChange = item.SellIn >= 0 ? item.ItemType.DailyQualityChange : item.ItemType.DailyQualityChangeAfterSellIn;

            item.SellIn--;

            if (item.SellIn >= 0)
            {
                for (int i = 0; i < Math.Min(item.ItemType.Milestones.Count, item.ItemType.QualityChangeOnMilestones.Count); i++)
                {
                    if (item.SellIn <= item.ItemType.Milestones[i])
                    {
                        qualityChange = item.ItemType.QualityChangeOnMilestones[i];
                    }
                }
            }

            item.Quality += qualityChange;

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
            if (item.ItemType.MaximumQuality >= 0 && item.Quality > item.ItemType.MaximumQuality)
            {
                item.Quality = item.ItemType.MaximumQuality;
            }
        }
    }
}
