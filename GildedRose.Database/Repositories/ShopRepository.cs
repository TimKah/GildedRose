using GildedRose.Database.DAO;
using GildedRose.Domain.Abstractions;
using GildedRose.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Database.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private string _itemsPath;
        private string _itemTypesPath;

        public ShopRepository(string itemsPath, string itemTypesPath)
        {
            _itemsPath = itemsPath;
            _itemTypesPath = itemTypesPath;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            List<ItemDAO> itemDAOs = await LoadItems();
            List<ItemTypeDAO> itemTypeDAOs = await LoadItemTypes();

            List<Item> items = new List<Item>(itemDAOs.Count);
            foreach (ItemDAO itemDAO in itemDAOs)
            {
                ItemTypeDAO itemTypeDAO = itemTypeDAOs.Where(i => i.Name == itemDAO.ItemType).FirstOrDefault();

                if (itemTypeDAO == null)
                {
                    throw new Exception();
                }

                items.Add(ConvertToItem(itemDAO, itemTypeDAO));
            }

            return items;
        }

        private Item ConvertToItem(ItemDAO itemDAO, ItemTypeDAO itemTypeDAO)
        {
            return new Item
            {
                Name = itemDAO.Name,
                SellIn = itemDAO.SellIn,
                Quality = itemDAO.Quality,
                ItemType = new ItemType
                {
                    Name = itemTypeDAO.Name,
                    MaximumQuality = itemTypeDAO.MaximumQuality ?? int.MaxValue,
                    DailyQualityChange = itemTypeDAO.DailyQualityChange ?? 0,
                    DailyQualityChangeAfterSellIn = itemTypeDAO.DailyQualityChangeAfterSellIn ?? 0,
                    Milestones = itemTypeDAO.Milestones ?? new List<int>(),
                    QualityChangeOnMilestones = itemTypeDAO.QualityChangeOnMilestones ?? new List<int>(),
                    SpecialFlags = itemTypeDAO.SpecialFlags ?? new List<string>()
                }
            };
        }

        private async Task<string> LoadJson(string path)
        {
            using StreamReader r = new StreamReader(path);

            return await r.ReadToEndAsync();
        }

        private async Task<List<ItemDAO>> LoadItems()
        {
            string json = await LoadJson(_itemsPath);

            return JsonConvert.DeserializeObject<List<ItemDAO>>(json);
        }

        private async Task<List<ItemTypeDAO>> LoadItemTypes()
        {
            string json = await LoadJson(_itemTypesPath);

            return JsonConvert.DeserializeObject<List<ItemTypeDAO>>(json);
        }
    }
}
