namespace DesignPatterns.Common.Rules;
public class ConjureRule : BaseRule
{
    public override bool Validate(Item item)
    {
        if (!base.Validate(item))
        {
            return false;
        }

        if (item.SellIn >= 0 && item.Quality != Constants.BaseQuality - (Constants.BaseSellIn - item.SellIn) * 2)
        {
            return false;
        }

        return true;
    }
}
