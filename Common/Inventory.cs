
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesignPatterns.Common;
public abstract class Inventory : IInventory
{
    protected readonly IList<Item> _items;

    protected Inventory(IList<Item> items) => _items = items;
    public abstract ReadOnlyCollection<Item> GetItems();
    public abstract void UpdateQuality();
}
