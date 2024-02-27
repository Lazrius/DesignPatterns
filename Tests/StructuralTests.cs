using DesignPatterns.Decorator;
using DesignPatterns.Facade;
using DesignPatterns.Original;
using FluentAssertions;

namespace DesignPatterns.Tests;
public class StructuralTests
{
    [Fact]
    public void DecoratorConstructsCorrectly()
    {
        InventoryDecorator inventoryDecorator = new(TestHarness.DefaultItems);
        inventoryDecorator.GetDecorators().Should().Equal(TestHarness.DefaultItems, (c1, c2) =>
            c1.GetName() == c2.Name &&
            c1.GetQuality() == c2.Quality &&
            c1.GetSellIn() == c2.SellIn);
    }

    [Fact]
    public void DecoratorUpdatesCorrectly()
    {
        InventoryDecorator inventoryDecorator = new(TestHarness.DefaultItems);
        inventoryDecorator.UpdateItems();

        // Grab the OG inventory to assert our values match
        var original = new GildedRose(TestHarness.DefaultItems);
        original.UpdateQuality();

        var other = new Mediator.GildedRose(TestHarness.DefaultItems);
        other.UpdateQuality();

        inventoryDecorator.GetDecorators().Should().Equal(original.GetItems(), (c1, c2) =>
            c1.GetName() == c2.Name &&
            c1.GetQuality() == c2.Quality &&
            c1.GetSellIn() == c2.SellIn);
    }

    [Fact]
    public void FacadeConstructsCorrectly()
    {
        foreach (var item in TestHarness.DefaultItems)
        {
            var facade = new ItemFacade(item.Name, item.Quality, item.SellIn);

            facade.GetName().Should().Be(item.Name);
            facade.GetQuality().Should().Be(item.Quality);
            facade.GetSellIn().Should().Be(item.SellIn);
        }
    }

    [Fact]
    public void FacadeUpdatesCorrectly()
    {
        var original = new GildedRose(TestHarness.DefaultItems);
        original.UpdateQuality();

        List<ItemFacade> facades = new();

        foreach (var item in TestHarness.DefaultItems)
        {
            var facade = new ItemFacade(item.Name, item.Quality, item.SellIn);
            facade.Update();

            facades.Add(facade);
        }

        facades.Should().Equal(original.GetItems(), (c1, c2) =>
            c1.GetName() == c2.Name &&
            c1.GetQuality() == c2.Quality &&
            c1.GetSellIn() == c2.SellIn);
    }
}
