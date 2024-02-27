using DesignPatterns.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesignPatterns.Refactored;

public class GildedRose : Inventory
{
    public GildedRose(IList<Item> items) : base(items)
    {
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality()
    {
        foreach (var item in _items)
        {
            if (item.Name == Constants.Sulfuras)
            {
                continue;
            }

            item.SellIn = Math.Clamp(item.SellIn - 1, 0, int.MaxValue);

            if (item.Name != Constants.AgedBrie && item.Name != Constants.BackstagePass)
            {
                item.Quality = Math.Clamp(item.Quality - 1, 0, int.MaxValue);
                if (item.Name == Constants.ConjuredManaCake && item.Quality != 0)
                {
                    item.Quality--;
                }
            }
            else if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == Constants.BackstagePass)
                {
                    if (item.SellIn < 11 && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }

                    if (item.SellIn < 6 && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
                else
                {
                    item.Quality++;
                }
            }

            if (item.SellIn > 0)
            {
                continue;
            }

            switch (item.Name)
            {
                case Constants.ConjuredManaCake:
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = Math.Clamp(item.Quality - 2, 0, 50);
                    }

                    break;
                }
                case Constants.AgedBrie:
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                    break;
                case Constants.BackstagePass:
                    item.Quality = 0;
                    break;
                default:
                    item.Quality = Math.Clamp(item.Quality - 1, 0, int.MaxValue);
                    break;
            }
        }
    }
}