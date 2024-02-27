using DesignPatterns.Common;
using DesignPatterns.Original;

namespace DesignPatterns.Builder;

public class InventoryBuilder
{
    private readonly Dictionary<string, Item> _items = new();

    public InventoryBuilder WithItem(string name, int quality, int sellIn)
    {
        _items[name] = new Item()
        {
            Name = name,
            Quality = quality,
            SellIn = sellIn
        };

        return this;
    }


    public Inventory Build()
    {
        return new GildedRose(_items.Values.ToList());
    }
}