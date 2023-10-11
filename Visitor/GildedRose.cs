using System.Collections.ObjectModel;
using DesignPatterns.Common;

namespace DesignPatterns.Visitor;

public class GildedRose : Inventory
{
    public GildedRose(IList<Item> items) : base(items)
    {
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality()
    {
        var visitor = new UpdateVisitor();
        foreach (var item in _items)
        {
            // Again, normally we wouldn't wrap this but it add it to item directly
            // But to keep it reusable we hack around it! ^^
            var wrapper = new ItemWrapper(item);
            visitor.Visit(wrapper);
        }
    }
}