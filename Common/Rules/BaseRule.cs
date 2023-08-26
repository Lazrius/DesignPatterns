namespace DesignPatterns.Common.Rules;
public class BaseRule
{
    public virtual bool Validate(Item item)
    {
        return item.Quality is <= 50 and >= 0;
    }
}
