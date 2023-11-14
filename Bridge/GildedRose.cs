using System.Collections.ObjectModel;
using DesignPatterns.Common;

namespace DesignPatterns.Bridge;

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
        var items = new AbstractItem(new ItemUpdater(_items));
        for (int i = 0; i < _items.Count; i++)
        {
            items.Update(i);
        }
    }
}