namespace DesignPatterns.Common.Rules;
public class BackstageRule : BaseRule
{
    public override bool Validate(Item item)
    {
        if (!base.Validate(item))
        {
            return false;
        }

        if (item.SellIn < 0)
        {
            return true;
        }

        var qualityTally = Constants.BackstageQuality;
        for (var i = Constants.BackstageSellIn; i != item.SellIn; i--)
        {
            qualityTally += i switch
            {
                > 10 => 1,
                > 5 => 2,
                _ => 3
            };
        }

        return item.Quality == qualityTally;
    }
}
