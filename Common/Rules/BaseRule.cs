namespace DesignPatterns.Common.Rules;
public class BaseRule
{
    public virtual bool Validate(Item item)
    {
        return item.Quality <= 50 && item.Quality >= 0;
    }
}
