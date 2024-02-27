using DesignPatterns.Common;
using System.Collections.ObjectModel;

namespace DesignPatterns.Command;

internal class UpdateItems : Command
{
    private readonly ReadOnlyCollection<Item> _items;
    public UpdateItems(ReadOnlyCollection<Item> items)
    {
        _items = items;
    }

    public override void Execute()
    {
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
