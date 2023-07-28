using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesignPatterns.Common;
public interface IInventory
{
    ReadOnlyCollection<Item> GetItems();
    void UpdateQuality();
}
