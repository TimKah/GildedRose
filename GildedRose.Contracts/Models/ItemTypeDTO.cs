using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Contracts.Models
{
    [JsonObject(Title = "itemType")]
    public sealed class ItemTypeDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "dailyQualityChange")]
        public int DailyQualityChange { get; set; }

        [JsonProperty(PropertyName = "dailyQualityChangeAfterSellIn")]
        public int DailyQualityChangeAfterSellIn { get; set; }

        [JsonProperty(PropertyName = "maximumQuality")]
        public int MaximumQuality { get; set; }

        [JsonProperty(PropertyName = "milestones")]
        public int[] Milestones { get; set; }

        [JsonProperty(PropertyName = "qualityChangeOnMilestones")]
        public int[] QualityChangeOnMilestones { get; set; }
    }
}
