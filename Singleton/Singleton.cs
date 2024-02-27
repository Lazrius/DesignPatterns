using DesignPatterns.Common;

namespace DesignPatterns.Singleton;
internal class Singleton
{
    private static Singleton? _instance;
    private IList<Item>? _items;

    internal static Singleton Instance => _instance ??= new Singleton();

    private Singleton()
    {
    }

    internal void SetItems(IList<Item> items)
    {
        _items = items;
    }

    internal void UpdateItems()
    {
        if (_items is null) 
        {
            throw new InvalidOperationException("SetItems was not called with a valid value.");
        }

        foreach (var item in _items)
        {
            (item.Quality, item.SellIn) = (item.Name) switch
            {
                Constants.AgedBrie => RuleHelper.AdjustItem(RuleType.Aged, item.Quality, item.SellIn),
                Constants.ConjuredManaCake => RuleHelper.AdjustItem(RuleType.Conjured, item.Quality, item.SellIn),
                Constants.BackstagePass => RuleHelper.AdjustItem(RuleType.Backstage, item.Quality, item.SellIn),
                Constants.Sulfuras => RuleHelper.AdjustItem(RuleType.Legendary, item.Quality, item.SellIn),
                _ => RuleHelper.AdjustItem(RuleType.Normal, item.Quality, item.SellIn),
            };
        }
    }
}
