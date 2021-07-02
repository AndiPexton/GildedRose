using GildedRose.Gateway;

namespace GildedRose.Core
{
    public static class ItemTypeExtensions
    {
        private const string AgedBrie = "Aged Brie";
        private const string Conjured = "Conjured";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        public static bool IsBackstagePasses(this IItem item) => 
            item.Name == BackstagePasses;

        public static bool IsNotSulfurasHandOfRagnaros(this IItem item) => 
            item.Name != SulfurasHandOfRagnaros;

        public static bool IsNotBackstagePasses(this IItem item) => 
            item.Name != BackstagePasses;

        public static bool IsNotAgedBrie(this IItem item) => 
            !IsAgedBrie(item);

        public static bool IsAgedBrie(this IItem item) => 
            item.Name == AgedBrie;

        public static bool IsConjured(this IItem item) =>
            item.Name == Conjured;

        public static bool IsNotAgedBrieOrBackstagePasses(this IItem item) =>
            item.IsNotAgedBrie()
            && item.IsNotBackstagePasses();
    }
}