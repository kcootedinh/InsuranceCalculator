using System;
using System.Linq;

namespace InsuranceCalculator.ConsoleApp
{
    public class LiabilityCalculator
    {
        private static readonly decimal[] AllowedLimits = { 1_000_000m, 2_000_000m, 5_000_000m, 10_000_000m, 20_000_000m, 30_000_000m };

        private decimal? limitForCalculation;

        public LiabilityCalculator WithLimit(in decimal limit)
        {
            if (!AllowedLimits.Contains(limit))
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be one of the allowed values.");
            }

            this.limitForCalculation = limit;
            return this;
        }

        public decimal CalculatePremium()
        {
            return decimal.One;
        }
    }
}