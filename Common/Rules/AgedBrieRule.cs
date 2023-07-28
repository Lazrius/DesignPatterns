namespace DesignPatterns.Common.Rules;
public class AgedRuleBrie : BaseRule
{
    public override bool Validate(Item item)
    {
        if (!base.Validate(item))
        {
            return false;
        }

        if (item.SellIn >= 0 && item.Quality != Constants.BaseQuality + (Constants.BaseSellIn - item.SellIn))
        {
            return false;
        }

        return true;
    }
}
