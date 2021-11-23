using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Database.DAO
{
    [JsonObject(Title = "item")]
    public sealed class ItemDAO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "sellIn")]
        public int SellIn { get; set; }

        [JsonProperty(PropertyName = "quality")]
        public int Quality { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string ItemType { get; set; }
    }
}
