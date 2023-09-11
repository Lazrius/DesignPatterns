using System.Collections.ObjectModel;
using DesignPatterns.Common;

namespace DesignPatterns.Command;

public class GildedRose : Inventory
{
    public GildedRose(IList<Item> items) : base(items)
    {
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality()
    {
        var command = new UpdateItems(GetItems());
        command.Execute();
    }
}