using System.Collections.ObjectModel;
using DesignPatterns.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Mediator;

public class GildedRose : Inventory
{
    private readonly IServiceProvider _provider;
    private readonly IMediator _mediator;

    public GildedRose(IList<Item> items) : base(items)
    {
        var services = new ServiceCollection();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(GildedRose).Assembly);
        });

        _provider = services.BuildServiceProvider();
        _mediator = _provider.GetService<IMediator>()!;
    }

    public override ReadOnlyCollection<Item> GetItems() => new(_items);

    public override void UpdateQuality()
    {
        for (var index = 0; index < _items.Count; index++)
        {
            var item = _items[index];
            _items[index] = _mediator.Send(new ItemWrapper(item)).Result;
        }
    }
}