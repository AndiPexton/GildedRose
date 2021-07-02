using GildedRose.Gateway;

namespace GildedRose.Core
{
    public static class QualityCheckExtensions
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public static bool IfQualityNotMinimum(this IItem item) => 
            item.Quality > MinQuality;

        public static bool NotMaxQuality(this IItem item) => 
            item.Quality < MaxQuality;
    }
}