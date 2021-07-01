using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private readonly List<Item> _items;

        public TestAssemblyTests() => _items = TestHelpers.GetStartingStock();

        [Theory]
        [MemberData(nameof(Data))]
        public void TestDay_X(int days, IEnumerable<Item> expected) => 
            _items
                .AgeByDays(days)
                .Should().BeEquivalentTo(expected);

        public static IEnumerable<object[]> Data()
        {
            yield return
                new object[]
                {
                    1,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                        new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21},
                        new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 5}
                    }
                };

            yield return
                new object[]
                {
                    2,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 8, Quality = 18},
                        new Item {Name = "Aged Brie", SellIn = 0, Quality = 2},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 3, Quality = 5},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 13,
                            Quality = 22
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = 1, Quality = 4}
                    }
                };

            yield return
                new object[]
                {
                    3,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 7, Quality = 17},
                        new Item {Name = "Aged Brie", SellIn = -1, Quality = 4},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 2, Quality = 4},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 12,
                            Quality = 23
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 3}
                    }
                };
            yield return
                new object[]
                {
                    4,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 6, Quality = 16},
                        new Item {Name = "Aged Brie", SellIn = -2, Quality = 6},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 1, Quality = 3},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 11,
                            Quality = 24
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = -1, Quality = 1}
                    }
                };
            yield return
                new object[]
                {
                    6,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 4, Quality = 14},
                        new Item {Name = "Aged Brie", SellIn = -4, Quality = 10},
                        new Item {Name = "Elixir of the Mongoose", SellIn = -1, Quality = 0},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 9,
                            Quality = 27
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = -3, Quality = 0}
                    }
                };
            yield return
                new object[]
                {
                    10,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10},
                        new Item {Name = "Aged Brie", SellIn = -8, Quality = 18},
                        new Item {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 0},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 5,
                            Quality = 35
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = -7, Quality = 0}
                    }
                };
            yield return
                new object[]
                {
                    15,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = -5, Quality = 0},
                        new Item {Name = "Aged Brie", SellIn = -13, Quality = 28},
                        new Item {Name = "Elixir of the Mongoose", SellIn = -10, Quality = 0},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 0,
                            Quality = 50
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = -12, Quality = 0}
                    }
                };
            yield return
                new object[]
                {
                    16,
                    new[]
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = -6, Quality = 0},
                        new Item {Name = "Aged Brie", SellIn = -14, Quality = 30},
                        new Item {Name = "Elixir of the Mongoose", SellIn = -11, Quality = 0},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = -1,
                            Quality = 0
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = -13, Quality = 0}
                    }
                };
        }
    }
}