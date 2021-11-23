using GildedRose.Controllers.Registration.Extensions;
using GildedRose.Database.Registration.Extensions;
using GildedRose.Domain.Abstractions;
using GildedRose.Services.Registration.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRose
{
    class Program
    {
        private static readonly string itemsPath = Environment.GetEnvironmentVariable("itemsPath")
            ?? throw new InvalidOperationException("You must set the 'itemsPath' environment variable");
        private static readonly string itemTypesPath = Environment.GetEnvironmentVariable("itemTypesPath")
            ?? throw new InvalidOperationException("You must set the 'itemTypesPath' environment variable");

        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddShopController()
                .AddShopRepository(itemsPath, itemTypesPath)
                .AddShopService()
                .BuildServiceProvider();

            IShopController shopController = serviceProvider.GetService<IShopController>();
            
            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (int j = 0; j < shopController.Items.Count; j++)
                {
                    Console.WriteLine(shopController.Items[j]);
                }
                Console.WriteLine();
                shopController.SimulateDay();
            }
        }
    }
}
