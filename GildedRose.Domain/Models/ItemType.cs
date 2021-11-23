using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Domain.Models
{
    public class ItemType
    {
        public string Name { get; set; }

        public int DailyQualityChange { get; set; }

        public int DailyQualityChangeAfterSellIn { get; set; }

        public int MaximumQuality { get; set; }

        public IList<int> Milestones { get; set; }

        public IList<int> QualityChangeOnMilestones { get; set; }

        public IList<string> SpecialFlags { get; set; }
    }
}
