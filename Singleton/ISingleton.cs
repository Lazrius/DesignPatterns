using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Common;

namespace DesignPatterns.Singleton;

public class GildedRose : Inventory
{
    private GildedRose(IList<Item> items) : base(items)
    {
    }

    public static GildedRose? Instance { get; private set; }

    public static void Init(IList<Item> items)
    {
        Instance = new GildedRose(items);
    }

    public override ReadOnlyCollection<Item> GetItems()
    {
        return new ReadOnlyCollection<Item>(_items);
    }

    public override void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == "123123")
            {

            }
        }
    }
}