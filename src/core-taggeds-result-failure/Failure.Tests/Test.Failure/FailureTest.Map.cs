#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Map_MapFailureCodeIsNull_ExpectArgumentNullException(
            bool isNotDefault)
        {
            var source = isNotDefault ? new Failure<SomeFailureCode>(SomeFailureCode.First, SomeString) : default;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Map<int>(null!));
            Assert.Equal("mapFailureCode", ex.ParamName);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown)]
        [InlineData(SomeFailureCode.First)]
        [InlineData(SomeFailureCode.Second)]
        [InlineData(SomeFailureCode.Third)]
        public void Map_SourceIsDefault_ExpectFailureCodeIsMappedAndFailureMessageIsEmpty(
            SomeFailureCode mappedFailureCode)
        {
            var source = default(Failure<int>);

            var actual = source.Map(_ => mappedFailureCode);
            var expected = new Failure<SomeFailureCode>(mappedFailureCode, EmptyString);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(MinusFifteen)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        [InlineData(int.MaxValue)]
        public void Map_SourceFailureMessageIsNull_ExpectFailureCodeIsMappedAndFailureMessageIsEmpty(
            int mappedFailureCode)
        {
            var source = new Failure<decimal>(decimal.One, null);

            var actual = source.Map(_ => mappedFailureCode);
            var expected = new Failure<int>(mappedFailureCode, EmptyString);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, EmptyString, Zero)]
        [InlineData(SomeFailureCode.Unknown, WhiteSpaceString, Zero)]
        [InlineData(SomeFailureCode.Unknown, TabString, Zero)]
        [InlineData(SomeFailureCode.Unknown, LowerSomeString, Zero)]
        [InlineData(SomeFailureCode.Unknown, SomeString, Zero)]
        [InlineData(SomeFailureCode.Unknown, SomeString, PlusFifteen)]
        [InlineData(SomeFailureCode.First, EmptyString, int.MinValue)]
        [InlineData(SomeFailureCode.Second, WhiteSpaceString, MinusFifteen)]
        [InlineData(SomeFailureCode.Third, TabString, PlusFifteen)]
        [InlineData(SomeFailureCode.First, SomeString, Zero)]
        [InlineData(SomeFailureCode.Third, UpperSomeString, int.MaxValue)]
        public void Map_SourceFailureMessageIsNotNull_ExpectFailureCodeIsMappedAndFailureMessageIsEqualToSource(
            SomeFailureCode sourceFailureCode,
            string sourceFailureMessage,
            int mappedFailureCode)
        {
            var source = new Failure<SomeFailureCode>(sourceFailureCode, sourceFailureMessage);

            var actual = source.Map(_ => mappedFailureCode);
            var expected = new Failure<int>(mappedFailureCode, sourceFailureMessage);

            Assert.Equal(expected, actual);
        }
    }
}