namespace DesignPatterns.Common;

public static class RuleHelper
{
    // Helper method to avoid having to rewrite the logic over and over
    // Intentionally avoiding using extension method as to properly test
    // that the various coding methods work as intended
    public static (int, int) AdjustItem(RuleType type, int quality, int sellIn)
    {
        if (type == RuleType.Legendary)
        {
            return (quality, sellIn);
        }

        sellIn--;

        switch (type)
        {
            case RuleType.Conjured:
                quality -= 2;
                break;
            case RuleType.Aged:
                quality++;
                break;
            case RuleType.Backstage:
                switch (sellIn)
                {
                    case <= 5 and > 0:
                        quality += 3;
                        break;
                    case <= 10 and > 0:
                        quality += 2;
                        break;
                    case > 0:
                        quality++;
                        break;
                    default:
                        quality = 0;
                        break;
                }

                break;
            default:
                quality--;
                break;
        }

        quality = quality switch
        {
            > 50 => 50,
            < 0 => 0,
            _ => quality
        };

        return (quality, sellIn);
    }
}

public enum RuleType
{
    Normal,
    Conjured,
    Legendary,
    Backstage,
    Aged
}