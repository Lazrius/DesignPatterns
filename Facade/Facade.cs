using DesignPatterns.Common;

namespace DesignPatterns.Facade;

public class NameHandler
{
    public string Name { get; }

    public NameHandler(string name)
    {
        Name = name;
    }

    public bool HasValidName() =>
        Name switch
        {
            Constants.AgedBrie => true,
            Constants.NormalItem => true,
            Constants.BackstagePass => true,
            Constants.Sulfuras => true,
            Constants.ConjuredManaCake => true,
            _ => false
        };
}

public class QualityHandler
{
    public int Quality { get; set; }

    public QualityHandler(int quality)
    {
        Quality = quality;
    }

    public void UpdateQuality(RuleType type, int sellIn)
    {
        Quality = RuleHelper.AdjustQuality(type, Quality, sellIn);
    }
}

public class SellInHandler
{
    public int SellIn { get; set; }

    public SellInHandler(int sellIn)
    {
        SellIn = sellIn;
    }

    public void UpdateSellIn(RuleType type)
    {
        SellIn = RuleHelper.AdjustSellIn(type, SellIn);
    }
}

public class ItemFacade
{
    private readonly NameHandler _nameHandler;
    private readonly QualityHandler _qualityHandler;
    private readonly SellInHandler _sellInHandler;

    public ItemFacade(string name, int quality, int sellIn)
    {
        _nameHandler = new NameHandler(name);
        _qualityHandler = new QualityHandler(quality);
        _sellInHandler = new SellInHandler(sellIn);
    }

    public string GetName() => _nameHandler.Name;
    public int GetQuality() => _qualityHandler.Quality;
    public int GetSellIn() => _sellInHandler.SellIn;

    public void Update()
    {
        var rule = GetName() switch
        {
            Constants.AgedBrie => RuleType.Aged,
            Constants.ConjuredManaCake => RuleType.Conjured,
            Constants.BackstagePass => RuleType.Backstage,
            Constants.Sulfuras => RuleType.Legendary,
            _ => RuleType.Normal,
        };

        // Sell In must go first
        _sellInHandler.UpdateSellIn(rule);
        _qualityHandler.UpdateQuality(rule, GetSellIn());
    }
}