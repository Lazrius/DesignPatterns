using DesignPatterns.Command;
using DesignPatterns.Common;
using DesignPatterns.Common.Rules;
using DesignPatterns.Memento;
using FluentAssertions;

namespace DesignPatterns.Tests;
public class TestHarness
{
    protected TestHarness() { }

    public static IList<Item> DefaultItems => new List<Item>()
    {
        new() { Name = Constants.AgedBrie, Quality = Constants.BaseQuality, SellIn = Constants.BaseSellIn },
        new() { Name = Constants.BackstagePass, Quality = Constants.BackstageQuality, SellIn = Constants.BackstageSellIn },
        new() { Name = Constants.Sulfuras, Quality = Constants.SulfurasQuality, SellIn = Constants.SulfurasSellIn },
        new() { Name = Constants.NormalItem, Quality = Constants.BaseQuality, SellIn = Constants.BaseSellIn },
        new() { Name = Constants.ConjuredManaCake, Quality = 10, SellIn = 20 },
    };

    public static TheoryData<Inventory> Inventories => new()
    {
        //new Original.GildedRose(DefaultItems),
        new Mediator.GildedRose(DefaultItems),
        new Command.GildedRose(DefaultItems),
        new Memento.GildedRose(DefaultItems),
    };

    protected static void ValidateRules(IInventory inventory)
    {
        foreach (var item in inventory.GetItems())
        {
            (item.Name switch
            {
                Constants.Sulfuras => new SulfurasRule().Validate(item),
                Constants.AgedBrie => new AgedRuleBrie().Validate(item),
                Constants.BackstagePass => new BackstageRule().Validate(item),
                Constants.ConjuredManaCake => new ConjureRule().Validate(item),
                _ => new BaseRule().Validate(item)
            }).Should().BeTrue($"{item.Name} should successfully be validated");
        }
    }
}