using DesignPatterns.Builder;
using DesignPatterns.Common;
using DesignPatterns.Factory;
using DesignPatterns.Prototype;
using FluentAssertions;

namespace DesignPatterns.Tests;
public class ConstructionTests
{
    [Fact]
    public void BuilderTest()
    {
        InventoryBuilder builder = new();

        foreach (var item in TestHarness.DefaultItems)
        {
            // Append the items
            builder.WithItem(item.Name, item.Quality, item.SellIn);
        }

        var inventory = builder.Build();

        inventory.GetItems().Should().Equal(TestHarness.DefaultItems, (c1, c2) =>
            c1.Name == c2.Name &&
            c1.Quality == c2.Quality &&
            c1.SellIn == c2.SellIn);
    }

    public static IEnumerable<object[]> Factories =>
        new List<object[]>
        {
            new object[] { new NormalItemFactory() },
            new object[] { new ConjuredManaCakeFactory() },
            new object[] { new SulfurasFactory() },
            new object[] { new BackstagePassFactory() },
            new object[] { new AgedBrieFactory() },
        };

    [Theory]
    [MemberData(nameof(Factories))]
    public void FactoriesConstructMatchingItems(ItemFactory factory)
    {
        var newItem = factory.CreateItem();

        TestHarness.DefaultItems.Should().Contain(x =>
            x.Name == newItem.Name && x.SellIn == newItem.SellIn && x.Quality == newItem.Quality);
    }

    public static IEnumerable<object[]> DefaultItems => TestHarness.DefaultItems.Select(x => new[] { (object)x });

    [Theory]
    [MemberData(nameof(DefaultItems))]
    public void PrototypeConstructMatchingItems(Item existingItem)
    {
        var prototype = new ItemPrototype(existingItem);
        var newItem = (prototype.Clone() as ItemPrototype)!;

        newItem.Should().BeEquivalentTo(existingItem);
    }
}
