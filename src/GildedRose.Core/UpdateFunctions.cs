using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Gateway;

namespace GildedRose.Core
{
    public static class UpdateFunctions
    {
        public static IList<IItem> UpdateQuality(this IList<IItem> items) =>
            items
                .Select(GetNewItemState)
                .ToList();

        private static IItem GetNewItemState(IItem item) =>
            item
                .DoInitialQualityChange()
                .DoSellInDecrementIfRequired()
                .DoAdditionalQualityChangesBasedOnSellIn();

        private static IItem DoAdditionalQualityChangesBasedOnSellIn(this IItem item) =>
            item.SellInPassed() 
                ? item
                    .IncrementQualityIfAgedBrie()
                    .DoNonAgedBrieSellInBasedQualityChanges() 
                : item;

        private static IItem DoSellInDecrementIfRequired(this IItem item) =>
            item.IsNotSulfurasHandOfRagnaros() 
                ? item.DecrementSellIn() 
                : item;

        private static IItem DoInitialQualityChange(this IItem item) =>
            item.IsNotAgedBrieOrBackstagePasses()
                ? item
                    .DecrementQualityIfNotSulfurasHandOrRagnaros()
                    .DoAdditionalDecrementForConjuredItem()
                : item
                    .IncrementQuantityIfNotMax()
                    .DoAdditionalIncrementsIfBackstagePasses();
                    
        private static IItem DoAdditionalDecrementForConjuredItem(this IItem item) =>
            item.IsConjured()
                ? item.DecrementQuantity() 
                : item;

        private static IItem DoNonAgedBrieSellInBasedQualityChanges(this IItem item) =>
            item.IsNotAgedBrie() 
                ? item
                    .DecrementQualityIfNotSulfurasHandOrRagnaros()
                    .ZeroIfBackstagePasses() 
                : item;

        private static IItem IncrementQualityIfAgedBrie(this IItem item) =>
            item.IsAgedBrie() 
                ? item.IncrementQuantityIfNotMax() 
                : item;

        private static IItem ZeroIfBackstagePasses(this IItem item) =>
            item.IsBackstagePasses() 
                ? item.ZeroQuality() 
                : item;

        private static IItem DoAdditionalIncrementsIfBackstagePasses(this IItem item) =>
            item.IsBackstagePasses() 
                ? item.DoAdditionalIncrementsForBackstagePassesNearSellIn() 
                : item;

        private static IItem DoAdditionalIncrementsForBackstagePassesNearSellIn(this IItem item) =>
            item.IsLast5Days() 
                ? item.IncrementTwiceIfNotMax() 
                : item.IncrementIfLast10Days();

        private static IItem IncrementTwiceIfNotMax(this IItem item) =>
            item
                .IncrementQuantityIfNotMax()
                .IncrementQuantityIfNotMax();

        private static IItem IncrementIfLast10Days(this IItem item) =>
            item.IsLast10Days()
                ? item.IncrementQuantityIfNotMax()
                : item;

    }
}