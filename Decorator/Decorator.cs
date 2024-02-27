using DesignPatterns.Common;

namespace DesignPatterns.Decorator;

public abstract class InventoryItem
{
    protected int Quality = 0;
    protected int SellIn = 0;

    protected InventoryItem(Item? item)
    {
        if (item is null)
        {
            return;
        }

        Quality = item.Quality;
        SellIn = item.SellIn;
    }

    public abstract string GetName();
    public virtual int GetQuality() => Quality;
    public virtual int GetSellIn() => SellIn;
    public abstract void Update();
}

public class Sulfuras : InventoryItem
{
    public Sulfuras(Item? item) : base(item)
    {
    }

    public override string GetName() => Constants.Sulfuras;
    public override void Update() => (Quality, SellIn) = RuleHelper.AdjustItem(RuleType.Legendary, Quality, SellIn);
}

public class AgedBrie : InventoryItem
{
    public AgedBrie(Item? item) : base(item)
    {
    }

    public override string GetName() => Constants.AgedBrie;
    public override void Update() => (Quality, SellIn) = RuleHelper.AdjustItem(RuleType.Aged, Quality, SellIn);
}

public class BackstagePass : InventoryItem
{
    public BackstagePass(Item? item) : base(item)
    {
    }

    public override string GetName() => Constants.BackstagePass;
    public override void Update() => (Quality, SellIn) = RuleHelper.AdjustItem(RuleType.Backstage, Quality, SellIn);
}

public class NormalItem : InventoryItem
{
    public NormalItem(Item? item) : base(item)
    {
    }

    public override string GetName() => Constants.NormalItem;
    public override void Update() => (Quality, SellIn) = RuleHelper.AdjustItem(RuleType.Normal, Quality, SellIn);
}

public class ConjuredManaCake : InventoryItem
{
    public ConjuredManaCake(Item? item) : base(item)
    {
    }

    public override string GetName() => Constants.ConjuredManaCake;
    public override void Update() => (Quality, SellIn) = RuleHelper.AdjustItem(RuleType.Conjured, Quality, SellIn);
}

public class Decorator : InventoryItem
{
    private readonly InventoryItem _item;
    public Decorator(InventoryItem item) : base(null)
    {
        _item = item;
    }

    public override string GetName() => _item.GetName();
    public override int GetQuality() => _item.GetQuality();
    public override int GetSellIn() => _item.GetSellIn();
    public override void Update() => _item.Update();
}

public class InventoryDecorator
{
    private readonly List<Decorator> _decorators = new();

    public InventoryDecorator(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            _decorators.Add(new Decorator(item.Name switch
            {
                Constants.AgedBrie => new AgedBrie(item),
                Constants.ConjuredManaCake => new ConjuredManaCake(item),
                Constants.BackstagePass => new BackstagePass(item),
                Constants.Sulfuras => new Sulfuras(item),
                _ => new NormalItem(item),
            }));
        }
    }

    public void UpdateItems() => _decorators.ForEach(x => x.Update());
    public IReadOnlyCollection<Decorator> GetDecorators() => _decorators;
}