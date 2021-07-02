using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using GildedRose.Gateway;
using Xunit;
using static Shadow.Quack.Duck;

namespace GildedRose.Tests
{
    /*
        We have recently signed a supplier of conjured items. This requires an update to our system:
        "Conjured" items degrade in Quality twice as fast as normal items
     */
    public class ConjuredItemTests
    {
        [Fact]
        public void TestConjuredItem()
        {
            var start = new[]
                {
                    Implement<IItem>(new {Name = "Conjured", SellIn = 9, Quality = 19})
                };

            var expected = new[]
            {
                Implement<IItem>(new {Name = "Conjured", SellIn = 8, Quality = 17})
            };

            start.AgeByDays(1).Should().BeEquivalentTo(expected);

        }

    }
}
