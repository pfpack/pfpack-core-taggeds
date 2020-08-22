#nullable enable

using PrimeFuncPack.UnitTest.Data;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateLong_ExpectSomeLongValue()
        {
            var actual = DataGenerator.GenerateLong();
            _ = Assert.IsType<long>(actual);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void GenerateLongWithMin_ExpectValueGreaterOrEqualThanMin(
            in int min)
        {
            var actual = DataGenerator.GenerateLong(min);
            Assert.True(actual >= min);
        }

        [Fact]
        public void GenerateLong_MinEqualsMaxLongValue_ExpectMaxLongValue()
        {
            var sourceValue = long.MaxValue;
            var actual = DataGenerator.GenerateLong(sourceValue);
            Assert.Equal(long.MaxValue, actual);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(15, 25)]
        [InlineData(-55, -25)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void GenerateLong_MaxGreaterOrEqualThanMin_ExpectSomeLongBetweenMinAndMax(
            in int min, in int max)
        {
            var actual = DataGenerator.GenerateLong(min: min, max: max);

            Assert.True(actual >= min);
            Assert.True(actual <= max);
        }

        [Fact]
        public void GenerateLong_MaxAndMinEqualMinLongValue_ExpectMinLongValue()
        {
            var sourceValue = long.MinValue;
            var actual = DataGenerator.GenerateLong(sourceValue, sourceValue);
            Assert.Equal(sourceValue, actual);
        }

        [Theory]
        [InlineData(26, 25)]
        [InlineData(-10, -15)]
        public void GenerateLong_MinGreaterThanMax_ExpectArgumentOutOfRangeException(
            in int min, in int max)
        {
            var sourceMin = min;
            var sourceMax = max;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = DataGenerator.GenerateLong(min: sourceMin, max: sourceMax));
            Assert.Equal("max", ex.ParamName);
        }
    }
}
