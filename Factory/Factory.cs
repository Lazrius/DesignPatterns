using DesignPatterns.Common;

namespace DesignPatterns.Factory;

public abstract class ItemFactory
{
    public abstract Item CreateItem();
}

public class SulfurasFactory : ItemFactory
{
    public override Item CreateItem()
    {
        return new Item()
        {
            Name = Constants.Sulfuras,
            Quality = Constants.SulfurasQuality,
            SellIn = Constants.SulfurasSellIn,
        };
    }
}

public class AgedBrieFactory : ItemFactory
{
    public override Item CreateItem()
    {
        return new Item()
        {
            Name = Constants.AgedBrie,
            Quality = Constants.BaseQuality,
            SellIn = Constants.BaseSellIn,
        };
    }
}

public class BackstagePassFactory : ItemFactory
{
    public override Item CreateItem()
    {
        return new Item()
        {
            Name = Constants.BackstagePass,
            Quality = Constants.BackstageQuality,
            SellIn = Constants.BackstageSellIn,
        };
    }
}

public class NormalItemFactory : ItemFactory
{
    public override Item CreateItem()
    {
        return new Item()
        {
            Name = Constants.NormalItem,
            Quality = Constants.BaseQuality,
            SellIn = Constants.BaseSellIn,
        };
    }
}

public class ConjuredManaCakeFactory : ItemFactory
{
    public override Item CreateItem()
    {
        return new Item()
        {
            Name = Constants.ConjuredManaCake,
            Quality = Constants.BaseQuality,
            SellIn = Constants.BaseSellIn,
        };
    }
}