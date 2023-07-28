using DesignPatterns.Common;
using DesignPatterns.Common.Rules;
using FluentAssertions;

namespace DesignPatterns.Tests;
public class TestHarness
{
    protected TestHarness() { }

    public static readonly IList<Item> DefaultItems = new List<Item>()
    {
        new Item { Name = Constants.AgedBrie, Quality = Constants.BaseQuality, SellIn = Constants.BaseSellIn },
        new Item { Name = Constants.BackstagePass, Quality = Constants.BackstageQuality, SellIn = Constants.BackstageSellIn },
        new Item { Name = Constants.Sulfuras, Quality = Constants.SulfurasQuality, SellIn = Constants.SulfurasSellIn },
        new Item { Name = Constants.NormalItem, Quality = Constants.BaseQuality, SellIn = Constants.BaseSellIn },
        //new Item { Name = Constants.ConjuredManaCake, Quality = 10, SellIn = 20 },
    };

    public static TheoryData<Inventory> Inventories => new()
    {
        new Original.GildedRose(DefaultItems),
    };

    protected static void ValidateRules(Inventory inventory)
    {
        foreach (var item in inventory.GetItems())
        {
            (item.Name switch
            {
                Constants.Sulfuras => new SulfurasRule().Validate(item),
                Constants.AgedBrie => new AgedRuleBrie().Validate(item),
                Constants.BackstagePass => new BackstageRule().Validate(item),
                Constants.ConjuredManaCake => new BackstageRule().Validate(item),
                _ => new BaseRule().Validate(item)
            }).Should().BeTrue($"{item.Name} should successfully be validated");
        }
    }
}