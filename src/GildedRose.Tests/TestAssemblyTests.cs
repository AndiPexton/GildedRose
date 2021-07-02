using System.Collections.Generic;
using FluentAssertions;
using GildedRose.Core;
using GildedRose.Gateway;
using Xunit;
using static Shadow.Quack.Duck;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private readonly IList<IItem> _items;

        public TestAssemblyTests() => _items = TestHelpers.GetStartingStock();

        [Theory]
        [MemberData(nameof(Data))]
        public void TestDay_X(int days, IEnumerable<IItem> expected) => 
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
                       Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19}),
                       Implement<IItem>(new {Name = "Aged Brie", SellIn = 1, Quality = 1}),
                       Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6}),
                       Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                       Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21}),
                       Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = 2, Quality = 5})
                    }
                };

            yield return
                new object[]
                {
                    2,
                    new[]
                    {
                        Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = 8, Quality = 18}),
                        Implement<IItem>(new {Name = "Aged Brie", SellIn = 0, Quality = 2}),
                        Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = 3, Quality = 5}),
                        Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 13, Quality = 22}),
                        Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = 1, Quality = 4})
                    }
                };

            yield return
                new object[]
                {
                    3,
                    new[]
                    {
                        Implement<IItem>(new  {Name = "+5 Dexterity Vest", SellIn = 7, Quality = 17}),
                        Implement<IItem>(new  {Name = "Aged Brie", SellIn = -1, Quality = 4}),
                        Implement<IItem>(new  {Name = "Elixir of the Mongoose", SellIn = 2, Quality = 4}),
                        Implement<IItem>(new  {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new  {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 23}),
                        Implement<IItem>(new  {Name = "Conjured Mana Cake", SellIn = 0, Quality = 3})
                    }
                };
            yield return
                new object[]
                {
                    4,
                    new[]
                    {
                        Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = 6, Quality = 16}),
                        Implement<IItem>(new {Name = "Aged Brie", SellIn = -2, Quality = 6}),
                        Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = 1, Quality = 3}),
                        Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 24}),
                        Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = -1, Quality = 1})
                    }
                };
            yield return
                new object[]
                {
                    6,
                    new[]
                    {
                        Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = 4, Quality = 14}),
                        Implement<IItem>(new {Name = "Aged Brie", SellIn = -4, Quality = 10}),
                        Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = -1, Quality = 0}),
                        Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 27}),
                        Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = -3, Quality = 0})
                    }
                };
            yield return
                new object[]
                {
                    10,
                    new[]
                    {
                        Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10}),
                        Implement<IItem>(new {Name = "Aged Brie", SellIn = -8, Quality = 18}),
                        Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 0}),
                        Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35}),
                        Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = -7, Quality = 0})
                    }
                };
            yield return
                new object[]
                {
                    15,
                    new[]
                    {
                        Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = -5, Quality = 0}),
                        Implement<IItem>(new {Name = "Aged Brie", SellIn = -13, Quality = 28}),
                        Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = -10, Quality = 0}),
                        Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50}),
                        Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = -12, Quality = 0})
                    }
                };
            yield return
                new object[]
                {
                    16,
                    new[]
                    {
                        Implement<IItem>(new {Name = "+5 Dexterity Vest", SellIn = -6, Quality = 0}),
                        Implement<IItem>(new {Name = "Aged Brie", SellIn = -14, Quality = 30}),
                        Implement<IItem>(new {Name = "Elixir of the Mongoose", SellIn = -11, Quality = 0}),
                        Implement<IItem>(new {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                        Implement<IItem>(new {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0}),
                        Implement<IItem>(new {Name = "Conjured Mana Cake", SellIn = -13, Quality = 0})
                    }
                };
        }
    }
}