using System.Collections.Generic;

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
