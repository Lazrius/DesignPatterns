using DesignPatterns.Common;
using DesignPatterns.Decorator;
using DesignPatterns.Original;
using FluentAssertions;

namespace DesignPatterns.Tests;

public class BehaviouralTests : TestHarness
{
    [Fact]
    public void RefactoredCodeMatchesOriginal()
    {
        var refactored = new Refactored.GildedRose(DefaultItems);
        refactored.UpdateQuality();

        var original = new GildedRose(DefaultItems);
        original.UpdateQuality();

        refactored.GetItems().Should().Equal(original.GetItems(), (c1, c2) =>
            c1.Name == c2.Name &&
            c1.Quality == c2.Quality &&
            c1.SellIn == c2.SellIn);
    }


    [Theory]
    [MemberData(nameof(Inventories), MemberType = typeof(TestHarness))]
    public void UpdateInventories(IInventory inventory)
    {
        inventory.UpdateQuality();

        ValidateRules(inventory);
    }

    [Theory]
    [MemberData(nameof(Inventories), MemberType = typeof(TestHarness))]
    public void UpdatedInventoriesMatchOriginal(IInventory inventory)
    {
        var original = new GildedRose(DefaultItems);
        original.UpdateQuality();

        inventory.UpdateQuality();

        inventory.GetItems().Should().Equal(original.GetItems(), (c1, c2) =>
            c1.Name == c2.Name &&
            c1.Quality == c2.Quality &&
            c1.SellIn == c2.SellIn);
    }
}