using DesignPatterns.Common;

namespace DesignPatterns.Memento;

public class Memento
{
    private readonly Item _item;
    public Memento(Item item)
    {
        _item = new()
        {
            Name = item.Name,
            SellIn = item.SellIn,
            Quality = item.Quality
        };
    }

    public Item RetreiveMemento() => new()
    {
        Name = _item.Name,
        SellIn = _item.SellIn,
        Quality = _item.Quality
    };
}