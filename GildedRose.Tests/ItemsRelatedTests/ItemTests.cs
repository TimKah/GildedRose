using GildedRose.Controllers;
using GildedRose.Domain.Abstractions;
using GildedRose.Domain.Models;
using GildedRose.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GildedRose.Tests.ItemsRelatedTests
{
    [TestClass]
    public class ItemTests
    {
        Mock<IShopRepository> shopRepositoryMock;
        ShopService shopService;
        ShopController shopController;
        List<Item> testItems;

        [TestInitialize]
        public void SetUp()
        {
            shopRepositoryMock = new Mock<IShopRepository>();
            shopService = new ShopService();
            testItems = new List<Item>
            {
                new Item
                {
                    Name = "Test item",
                    SellIn = 0,
                    Quality = 0,
                    ItemType = new ItemType
                    {
                        Name = "Test type",
                        MaximumQuality = 0,
                        DailyQualityChange = 0,
                        DailyQualityChangeAfterSellIn = 0,
                        Milestones = new List<int>(),
                        QualityChangeOnMilestones = new List<int>(),
                        SpecialFlags = new List<string>()
                    }
                }
            };

            shopRepositoryMock.Setup(x => x.GetItemsAsync()).ReturnsAsync(testItems);
        }

        [TestMethod]
        public void CheckLedgendaryFlag()
        {
            testItems[0].SellIn = 10;
            testItems[0].Quality = 100;
            testItems[0].ItemType.SpecialFlags.Add("LEGENDARY");

            shopController = new ShopController(shopRepositoryMock.Object, shopService);

            shopController.SimulateDay();

            Assert.IsTrue(shopController.Items[0].SellIn == 10);
            Assert.IsTrue(shopController.Items[0].Quality == 100);
        }
        [TestMethod]
        public void CheckAgingBeforeSellIn()
        {
            testItems[0].SellIn = 10;
            testItems[0].Quality = 100;
            testItems[0].ItemType.DailyQualityChange = -1;
            testItems[0].ItemType.MaximumQuality = 100;

            shopController = new ShopController(shopRepositoryMock.Object, shopService);

            for (int i = 0; i < 10; i++)
            {
                shopController.SimulateDay();
            }

            Assert.IsTrue(shopController.Items[0].SellIn == 0);
            Assert.IsTrue(shopController.Items[0].Quality == 90);
        }

        [TestMethod]
        public void CheckAgingAfterSellIn()
        {
            testItems[0].SellIn = -1;
            testItems[0].Quality = 100;
            testItems[0].ItemType.DailyQualityChangeAfterSellIn = -2;
            testItems[0].ItemType.MaximumQuality = 100;

            shopController = new ShopController(shopRepositoryMock.Object, shopService);

            for (int i = 0; i < 10; i++)
            {
                shopController.SimulateDay();
            }

            Assert.IsTrue(shopController.Items[0].SellIn == -11);
            Assert.IsTrue(shopController.Items[0].Quality == 80);
        }

        [TestMethod]
        public void CheckMaxQuality()
        {
            testItems[0].SellIn = 100;
            testItems[0].Quality = 0;
            testItems[0].ItemType.DailyQualityChange = 1;
            testItems[0].ItemType.MaximumQuality = 20;

            shopController = new ShopController(shopRepositoryMock.Object, shopService);

            for (int i = 0; i < 100; i++)
            {
                shopController.SimulateDay();
            }

            Assert.IsTrue(shopController.Items[0].Quality == shopController.Items[0].ItemType.MaximumQuality);
        }

        [TestMethod]
        public void CheckMilestones()
        {
            testItems[0].SellIn = 31;
            testItems[0].Quality = 0;
            testItems[0].ItemType.Milestones = new List<int> { 20, 10 };
            testItems[0].ItemType.QualityChangeOnMilestones = new List<int> { 2, 3 };
            testItems[0].ItemType.DailyQualityChange = 1;
            testItems[0].ItemType.MaximumQuality = 100;

            shopController = new ShopController(shopRepositoryMock.Object, shopService);

            for (int i = 0; i < 10; i++)
            {
                shopController.SimulateDay();
            }

            Assert.IsTrue(shopController.Items[0].Quality == 10);

            for (int i = 0; i < 10; i++)
            {
                shopController.SimulateDay();
            }

            Assert.IsTrue(shopController.Items[0].Quality == 30);

            for (int i = 0; i < 10; i++)
            {
                shopController.SimulateDay();
            }

            Assert.IsTrue(shopController.Items[0].Quality == 60);
        }
    }
}
