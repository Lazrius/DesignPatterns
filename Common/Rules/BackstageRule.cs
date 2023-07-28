namespace DesignPatterns.Common.Rules;
public class BackstageRule : BaseRule
{
    public override bool Validate(Item item)
    {
        if (!base.Validate(item))
        {
            return false;
        }

        if (item.SellIn >= 0)
        {
            int qualityTally = Constants.BackstageQuality;
            for (int i = Constants.BackstageSellIn; i != item.SellIn; i--)
            {
                if (i > 10)
                {
                    qualityTally += 1;
                }
                else if (i > 5)
                {
                    qualityTally += 2;
                }
                else
                {
                    qualityTally += 3;
                }
            }

            if (item.Quality != qualityTally)
            {
                return false;
            }
        }

        return true;
    }
}
