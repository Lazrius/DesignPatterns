using System;

namespace DesignPatterns.Common;

public static class RuleHelper
{
    // Helper method to avoid having to rewrite the logic over and over
    // Intentionally avoiding using extension method as to properly test
    // that the various coding methods work as intended
    public static (int, int) AdjustItem(RuleType type, int quality, int sellIn)
    {
        sellIn = AdjustSellIn(type, sellIn);
        quality = AdjustQuality(type, quality, sellIn);

        return (quality, sellIn);
    }

    public static int AdjustSellIn(RuleType type, int sellIn)
    {
        return type is RuleType.Legendary ? sellIn : sellIn - 1;
    }

    public static int AdjustQuality(RuleType type, int quality, int sellIn)
    {
        if (type == RuleType.Legendary)
        {
            return quality;
        }

        switch (type)
        {
            case RuleType.Conjured:
                quality -= 2;
                break;
            case RuleType.Aged:
                quality++;
                if (sellIn < 50)
                {
                    quality++;
                }
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

        if (sellIn > 0)
        {
            return quality;
        }

        switch (quality)
        {
            case < 50 when type == RuleType.Aged:
                quality++;
                break;
            case > 0 when type == RuleType.Conjured:
                quality = Math.Clamp(quality - 2, 0, 50);
                break;
            default:
            {
                quality = type == RuleType.Backstage ? 0 : Math.Clamp(quality - 1, 0, int.MaxValue);
                break;
            }
        }

        return quality;
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