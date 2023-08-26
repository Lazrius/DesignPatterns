using DesignPatterns.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesignPatterns.Original;

public class GildedRose : Inventory
{
    public GildedRose(IList<Item> items) : base(items)
    {
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i].Name != Constants.AgedBrie && _items[i].Name != Constants.BackstagePass)
            {
                if (_items[i].Quality > 0)
                {
                    if (_items[i].Name != Constants.Sulfuras)
                    {
                        _items[i].Quality = _items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (_items[i].Quality < 50)
                {
                    _items[i].Quality = _items[i].Quality + 1;

                    if (_items[i].Name == Constants.BackstagePass)
                    {
                        if (_items[i].SellIn < 11)
                        {
                            if (_items[i].Quality < 50)
                            {
                                _items[i].Quality = _items[i].Quality + 1;
                            }
                        }

                        if (_items[i].SellIn < 6)
                        {
                            if (_items[i].Quality < 50)
                            {
                                _items[i].Quality = _items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (_items[i].Name != Constants.Sulfuras)
            {
                _items[i].SellIn = _items[i].SellIn - 1;
            }

            if (_items[i].SellIn > 0)
            {
                if (_items[i].Name != Constants.AgedBrie)
                {
                    if (_items[i].Name != Constants.BackstagePass)
                    {
                        if (_items[i].Name == Constants.ConjuredManaCake)
                        {
                            if (_items[i].Quality > 0)
                            {
                                _items[i].Quality = Math.Clamp(_items[i].Quality - 2, 0, 50);
                            }
                            continue;
                        }
                        if (_items[i].Quality > 0)
                        {
                            if (_items[i].Name != Constants.Sulfuras)
                            {
                                _items[i].Quality = _items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        _items[i].Quality = _items[i].Quality - _items[i].Quality;
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;
                    }
                }
            }
        }
    }
}