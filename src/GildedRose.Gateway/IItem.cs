namespace GildedRose.Gateway
{
    public interface IItem
    {
        string Name { get; }
        int SellIn { get; }
        int Quality { get; }
    }
}