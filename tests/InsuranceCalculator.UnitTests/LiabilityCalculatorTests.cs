using System;
using InsuranceCalculator.ConsoleApp;
using Shouldly;
using Xunit;

namespace InsuranceCalculator.UnitTests
{
    public class LiabilityCalculatorTests
    {
        [Theory]
        [InlineData(1_000_000)]
        [InlineData(2_000_000)]
        [InlineData(5_000_000)]
        [InlineData(10_000_000)]
        [InlineData(20_000_000)]
        [InlineData(30_000_000)]
        public void ShouldAllowLimitFromAllowedValues(decimal limit)
        {
            var sut = new LiabilityCalculator().WithLimit(limit);

            sut.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void ShouldNotAllowSmallAmounts(decimal limit)
        {
            Action action = () => new LiabilityCalculator().WithLimit(limit);

            action.ShouldThrow<Exception>();
        }

        [Theory]
        [InlineData(1_050_000)]
        [InlineData(12_500_010)]
        [InlineData(16_000_000.50)]
        public void ShouldNotAllowStrangeAmounts(decimal limit)
        {
            Action action = () => new LiabilityCalculator().WithLimit(limit);

            action.ShouldThrow<Exception>();
        }

        [Theory]
        [InlineData(30_000_001)]
        [InlineData(100_000_000)]
        public void ShouldNotAllowAmountsLargerThan30Million(decimal limit)
        {
            Action action = () => new LiabilityCalculator().WithLimit(limit);

            action.ShouldThrow<Exception>();
        }
    }
}