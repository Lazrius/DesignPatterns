using DesignPatterns.Common;
using System.Reflection;

namespace DesignPatterns.Tests;

public class UpdateQualityTests : TestHarness
{
    [Theory]
    [MemberData(nameof(Inventories), MemberType = typeof(TestHarness))]
    public void Test1(Inventory inventory)
    {
        inventory.UpdateQuality();

        ValidateRules(inventory);
    }
}