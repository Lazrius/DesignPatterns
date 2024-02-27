using DesignPatterns.Common;

namespace DesignPatterns.Prototype;

public abstract class Prototype
{
    public abstract Prototype Clone();
}

public class ItemPrototype : Prototype
{
    public string Name { get; set; }
    public int Quality { get; set; }
    public int SellIn { get; set; }

    public ItemPrototype(Item item)
    {
        Name = item.Name;
        Quality = item.Quality;
        SellIn = item.SellIn;
    }

    public override Prototype Clone() => (MemberwiseClone() as ItemPrototype)!;
}