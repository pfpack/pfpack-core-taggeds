#nullable enable

using PrimeFuncPack.UnitTest.Data;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateDecimal_ExpectSomeDecimalValue()
        {
            var actual = DataGenerator.GenerateDecimal();
            _ = Assert.IsType<decimal>(actual);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void GenerateDecimalWithMin_ExpectValueGreaterOrEqualThanMin(
            in int min)
        {
            var actual = DataGenerator.GenerateDecimal(min);
            Assert.True(actual >= min);
        }

        [Fact]
        public void GenerateDecimal_MinEqualsMaxDecimalValue_ExpectMaxDecimalValue()
        {
            var sourceValue = decimal.MaxValue;
            var actual = DataGenerator.GenerateDecimal(sourceValue);
            Assert.Equal(sourceValue, actual);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(15, 25)]
        [InlineData(-55, -25)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void GenerateDecimal_MaxGreaterOrEqualThanMin_ExpectSomeDecimalBetweenMinAndMax(
            in int min, in int max)
        {
            var actual = DataGenerator.GenerateDecimal(min: min, max: max);

            Assert.True(actual >= min);
            Assert.True(actual <= max);
        }

        [Fact]
        public void GenerateDecimal_MaxAndMinEqualMinDecimalValue_ExpectMinDecimalValue()
        {
            var sourceValue = decimal.MinValue;
            var actual = DataGenerator.GenerateDecimal(sourceValue, sourceValue);
            Assert.Equal(sourceValue, actual);
        }

        [Theory]
        [InlineData(26, 25)]
        [InlineData(-10, -15)]
        public void GenerateDecimal_MinGreaterThanMax_ExpectArgumentOutOfRangeException(
            in int min, in int max)
        {
            var sourceMin = min;
            var sourceMax = max;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = DataGenerator.GenerateDecimal(min: sourceMin, max: sourceMax));
            Assert.Equal("max", ex.ParamName);
        }
    }
}
