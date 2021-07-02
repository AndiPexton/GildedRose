using GildedRose.Gateway;
using Shadow.Quack;

namespace GildedRose.Core
{
    public static class NewValueExtensions
    {
      
        public static IItem ZeroQuality(this IItem item) =>
            Duck.Merge<IItem>(item, new
            {
                Quality = 0
            });

        public static IItem DecrementSellIn(this IItem item) =>
            Duck.Merge<IItem>(item, new
            {
                SellIn = item.SellIn - 1
            });

        public static IItem DecrementQualityIfNotSulfurasHandOrRagnaros(this IItem item) =>
            item.NotMinQualityAndNotSulfurasHandOfRagnaros() 
                ? item.DecrementQuantity() 
                : item;

        public static IItem DecrementQuantity(this IItem item) =>
            Duck.Merge<IItem>(item, new
            {
                Quality = item.Quality - 1
            });

        private static bool NotMinQualityAndNotSulfurasHandOfRagnaros(this IItem item) => 
            item.IfQualityNotMinimum() 
            && item.IsNotSulfurasHandOfRagnaros();

        public static IItem IncrementQuantityIfNotMax(this IItem item) =>
            item.NotMaxQuality() 
                ? IncrementQuality(item) 
                : item;

        private static IItem IncrementQuality(this IItem item) =>
            Duck.Merge<IItem>(item, new
            {
                Quality = item.Quality + 1
            });
    }
}