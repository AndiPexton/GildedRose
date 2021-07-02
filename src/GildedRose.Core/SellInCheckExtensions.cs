using GildedRose.Gateway;

namespace GildedRose.Core
{
    public static class SellInCheckExtensions
    {
        public static bool SellInPassed(this IItem item) => 
            item.SellIn < 0;

        public static bool IsLast5Days(this IItem item) => 
            item.SellIn < 6;

        public static bool IsLast10Days(this IItem item) => 
            item.SellIn < 11;
    }
}