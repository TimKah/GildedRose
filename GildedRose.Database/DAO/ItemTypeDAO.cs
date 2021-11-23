using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Database.DAO
{
    [JsonObject(Title = "itemType")]
    public sealed class ItemTypeDAO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "dailyQualityChange")]
        public int? DailyQualityChange { get; set; }

        [JsonProperty(PropertyName = "dailyQualityChangeAfterSellIn")]
        public int? DailyQualityChangeAfterSellIn { get; set; }

        [JsonProperty(PropertyName = "maximumQuality")]
        public int? MaximumQuality { get; set; }

        [JsonProperty(PropertyName = "milestones")]
        public IList<int> Milestones { get; set; }

        [JsonProperty(PropertyName = "qualityChangeOnMilestones")]
        public IList<int> QualityChangeOnMilestones { get; set; }

        [JsonProperty(PropertyName = "specialFlags")]
        public IList<string> SpecialFlags { get; set; }
    }
}
