using DesignPatterns.Common;
using System.Linq;

namespace DesignPatterns.Bridge;

// The abstraction
internal class AbstractItem
{
    private readonly ItemWrapper _itemWrapper;

    internal AbstractItem(ItemWrapper item)
    {
        _itemWrapper = item;
    }

    internal virtual void Update(int itemIndex) => _itemWrapper.UpdateItem(itemIndex);
}

// Optional: Refined Abstraction with overrides - not needed here

// The implementor abstraction
internal abstract class ItemWrapper
{
    internal abstract void UpdateItem(int itemIndex);
}

// The implementor
internal class ItemUpdater : ItemWrapper
{
    private readonly IList<Item> _items;

    public ItemUpdater(IList<Item> items)
    {
        _items = items;
    }

    internal override void UpdateItem(int itemIndex)
    {
        if (itemIndex >= _items.Count || itemIndex < 0) 
        {
            throw new ArgumentOutOfRangeException(nameof(itemIndex));
        }

        var item = _items[itemIndex];

        _ = item.Name switch
        {
            Constants.AgedBrie => RuleHelper.AdjustItem(RuleType.Aged, item.Quality, item.SellIn),
            Constants.ConjuredManaCake => RuleHelper.AdjustItem(RuleType.Conjured, item.Quality, item.SellIn),
            Constants.BackstagePass => RuleHelper.AdjustItem(RuleType.Backstage, item.Quality, item.SellIn),
            Constants.Sulfuras => RuleHelper.AdjustItem(RuleType.Legendary, item.Quality, item.SellIn),
            _ => RuleHelper.AdjustItem(RuleType.Normal, item.Quality, item.SellIn),
        };
    }
}