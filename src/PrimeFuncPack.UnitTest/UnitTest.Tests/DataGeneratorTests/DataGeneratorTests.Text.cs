#nullable enable

using PrimeFuncPack.UnitTest.Data;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        private const int MaxByteValueAsInt = byte.MaxValue;
        private const int MinByteValueAsInt = byte.MinValue;

        [Fact]
        public void Empty_ExpectEmptyString()
        {
            var actual = DataGenerator.Empty;
            Assert.Empty(actual);
        }

        [Fact]
        public void GenerateText_ExpectSomeNotEmptyString()
        {
            var actual = DataGenerator.GenerateText();
            Assert.NotEmpty(actual);
        }

        [Theory]
        [InlineData(MinByteValueAsInt)]
        [InlineData(15)]
        [InlineData(MaxByteValueAsInt)]
        public void GenerateTextWithLength_ExpectSomeStringWithActualLength(
            in int length)
        {
            var actual = DataGenerator.GenerateText(length: (byte)length);
            var actualLength = actual.Length;

            Assert.Equal(length, actualLength);
        }

        [Theory]
        [InlineData(MinByteValueAsInt, MinByteValueAsInt)]
        [InlineData(MinByteValueAsInt, MaxByteValueAsInt)]
        [InlineData(15, 25)]
        [InlineData(MaxByteValueAsInt, MaxByteValueAsInt)]
        public void GenerateText_MaxGreaterOrEqualThanMin_ExpectSomeStringWithLengthBetweenMinAndMax(
            in int min, in int max)
        {
            var actual = DataGenerator.GenerateText(minLength: (byte)min, maxLength: (byte)max);
            var actualLength = actual.Length;

            Assert.True(actualLength >= min);
            Assert.True(actualLength <= max);
        }

        [Theory]
        [InlineData(26, 25)]
        public void GenerateText_MinGreaterThanMax_ExpectArgumentOutOfRangeException(
            in int minLength, in int maxLength)
        {
            var sourceMin = (byte)minLength;
            var sourceMax = (byte)maxLength;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = DataGenerator.GenerateText(minLength: sourceMin, maxLength: sourceMax));
            Assert.Equal("maxLength", ex.ParamName);
        }
    }
}
