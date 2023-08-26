using DesignPatterns.Common;
using System.Reflection;

namespace DesignPatterns.Tests;

public class UpdateQualityTests : TestHarness
{
    [Theory]
    [MemberData(nameof(Inventories), MemberType = typeof(TestHarness))]
    public void UpdateInventories(IInventory inventory)
    {
        inventory.UpdateQuality();

        ValidateRules(inventory);
    }
}