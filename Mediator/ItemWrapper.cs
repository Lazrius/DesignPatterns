using DesignPatterns.Common;
using MediatR;

namespace DesignPatterns.Mediator;

public class ItemWrapper : IRequest<Item>
{
    public readonly Item Item;
    public ItemWrapper(Item oldItem)
    {
        Item = oldItem;
    }
}

public class ItemHandler : IRequestHandler<ItemWrapper, Item>
{
    public Task<Item> Handle(ItemWrapper request, CancellationToken cancellationToken)
    {
        var result = (request.Item.Name) switch
        {
            Constants.AgedBrie => RuleHelper.AdjustItem(RuleType.Aged, request.Item.Quality, request.Item.SellIn),
            Constants.ConjuredManaCake => RuleHelper.AdjustItem(RuleType.Conjured, request.Item.Quality, request.Item.SellIn),
            Constants.BackstagePass => RuleHelper.AdjustItem(RuleType.Backstage, request.Item.Quality, request.Item.SellIn),
            Constants.Sulfuras => RuleHelper.AdjustItem(RuleType.Legendary, request.Item.Quality, request.Item.SellIn),
            _ => RuleHelper.AdjustItem(RuleType.Normal, request.Item.Quality, request.Item.SellIn),
        };

        return Task.FromResult(new Item()
        {
            Name = request.Item.Name,
            Quality = result.Item1,
            SellIn = result.Item2,
        });
    }
}