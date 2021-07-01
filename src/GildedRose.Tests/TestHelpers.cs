using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public static class TestHelpers
    {
        public static IList<Item> AgeByDays(this List<Item> items, int days) => 
            Enumerable
                .Range(1,days)
                .Aggregate<int, IList<Item>>(items, (current, day) => current.UpdateQuality());

        public static List<Item> GetStartingStock() =>
            new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
    }
}