using DesignPatterns.Common;

namespace DesignPatterns.Visitor;

internal interface IElement
{
    void Update(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

internal interface IVisitor
{
    void Visit(IElement element);
}

// Wrapper to use our common type to save on code duplication
internal class ItemWrapper : IElement
{
    internal Item Item { get; }
    internal ItemWrapper(Item item)
    {
        Item = item;
    }
}

internal class UpdateVisitor : IVisitor
{
    public void Visit(IElement element)
    {
        var wrapper = element as ItemWrapper;

        // TODO: If this was a proper example, each of the properties would have their own visitor and the logic would be duplicated
        // But as a POC this is fine. If have time at the end, revisit and properly implement.

        var item = wrapper!.Item;

        _ = (item.Name) switch
        {
            Constants.AgedBrie => RuleHelper.AdjustItem(RuleType.Aged, item.Quality, item.SellIn),
            Constants.ConjuredManaCake => RuleHelper.AdjustItem(RuleType.Conjured, item.Quality, item.SellIn),
            Constants.BackstagePass => RuleHelper.AdjustItem(RuleType.Backstage, item.Quality, item.SellIn),
            Constants.Sulfuras => RuleHelper.AdjustItem(RuleType.Legendary, item.Quality, item.SellIn),
            _ => RuleHelper.AdjustItem(RuleType.Normal, item.Quality, item.SellIn),
        };
    }
}
