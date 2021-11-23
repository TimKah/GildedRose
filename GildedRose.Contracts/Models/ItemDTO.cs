using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Contracts.Models
{
    [JsonObject(Title = "item")]
    public sealed class ItemDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "sellIn")]
        public int SellIn { get; set; }

        [JsonProperty(PropertyName = "quality")]
        public int Quality { get; set; }

        [JsonProperty(PropertyName = "itemType")]
        public ItemTypeDTO ItemType { get; set; }
    }
}
