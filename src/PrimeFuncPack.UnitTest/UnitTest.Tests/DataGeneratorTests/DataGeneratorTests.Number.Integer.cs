#nullable enable

using PrimeFuncPack.UnitTest.Data;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateInteger_ExpectSomeIntegerValue()
        {
            var actual = DataGenerator.GenerateInteger();
            _ = Assert.IsType<int>(actual);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void GenerateIntegerWithMin_ExpectValueGreaterOrEqualThanMin(
            in int min)
        {
            var actual = DataGenerator.GenerateInteger(min);
            Assert.True(actual >= min);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(15, 25)]
        [InlineData(-55, -25)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void GenerateInteger_MaxGreaterOrEqualThanMin_ExpectSomeIntegerBetweenMinAndMax(
            in int min, in int max)
        {
            var actual = DataGenerator.GenerateInteger(min: min, max: max);

            Assert.True(actual >= min);
            Assert.True(actual <= max);
        }

        [Theory]
        [InlineData(26, 25)]
        [InlineData(-10, -15)]
        public void GenerateInteger_MinGreaterThanMax_ExpectArgumentOutOfRangeException(
            in int min, in int max)
        {
            var sourceMin = min;
            var sourceMax = max;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = DataGenerator.GenerateInteger(min: sourceMin, max: sourceMax));
            Assert.Equal("max", ex.ParamName);
        }
    }
}
