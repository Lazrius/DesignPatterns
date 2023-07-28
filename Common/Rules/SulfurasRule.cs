namespace DesignPatterns.Common.Rules;
public class SulfurasRule : BaseRule
{
    public override bool Validate(Item item)
    {
        return item.Quality == Constants.SulfurasQuality && item.SellIn == Constants.SulfurasSellIn;
    }
}
