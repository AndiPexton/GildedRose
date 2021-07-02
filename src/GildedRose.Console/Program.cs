using System.Collections.Generic;
using GildedRose.Core;
using GildedRose.Gateway;
using static Shadow.Quack.Duck;

namespace GildedRose.Console
{
    class Program
    {
        IList<IItem> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new []
                                          {
                                              Implement<IItem>(new  {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}),
                                              Implement<IItem>(new  {Name = "Aged Brie", SellIn = 2, Quality = 0}),
                                              Implement<IItem>(new  {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}),
                                              Implement<IItem>(new  {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
                                              Implement<IItem>(new  {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20}),
                                              Implement<IItem>(new  {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6})
                                          }

                          };

            app.Items = app.Items.UpdateQuality();

            System.Console.ReadKey();

        }
    }
}
