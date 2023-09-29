using System.Collections.ObjectModel;
using DesignPatterns.Common;

namespace DesignPatterns.Command;

public class GildedRose : Inventory
{
    private readonly Invoker _invoker = new();
    public GildedRose(IList<Item> items) : base(items)
    {
        _invoker.SetCommand(new UpdateItems(GetItems()));
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality() => _invoker.ExecuteCommand();
}