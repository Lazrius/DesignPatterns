using System.Collections.ObjectModel;
using DesignPatterns.Common;

namespace DesignPatterns.Singleton;

public class GildedRose : Inventory
{
    public GildedRose(IList<Item> items) : base(items)
    {
    }

    public override ReadOnlyCollection<Item> GetItems()
    {
        return new ReadOnlyCollection<Item>(_items);
    }

    public override void UpdateQuality()
    {
        Singleton.Instance.SetItems(_items);
        Singleton.Instance.UpdateItems();
    }
}