using System.Collections.ObjectModel;
using DesignPatterns.Common;

namespace DesignPatterns.Memento;

public class GildedRose : Inventory
{
    private readonly List<Memento> _mementos = new();
    public GildedRose(IList<Item> items) : base(items)
    {
        // Pre-empt the update so we can 'restore' it duing the update step as a POC
        foreach (var item in _items)
        {
            _ = item.Name switch
            {
                Constants.AgedBrie => RuleHelper.AdjustItem(RuleType.Aged, item.Quality, item.SellIn),
                Constants.ConjuredManaCake => RuleHelper.AdjustItem(RuleType.Conjured, item.Quality, item.SellIn),
                Constants.BackstagePass => RuleHelper.AdjustItem(RuleType.Backstage, item.Quality, item.SellIn),
                Constants.Sulfuras => RuleHelper.AdjustItem(RuleType.Legendary, item.Quality, item.SellIn),
                _ => RuleHelper.AdjustItem(RuleType.Normal, item.Quality, item.SellIn),
            };

            _mementos.Add(new(item));

            // 'corrupt' the item
            item.Name = "garbage";
            item.SellIn = int.MaxValue;
            item.Quality = int.MinValue;
        }
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality()
    {
        // Restore the memories 
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i] = _mementos[i].RetreiveMemento();
        }
    }
}