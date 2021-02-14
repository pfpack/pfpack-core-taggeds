#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureStaticTest
    {
        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(MinusFifteen)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        [InlineData(int.MaxValue)]
        public void Create_SourceFailureMessageIsNull_ExpectFailureCodeIsEqualToSourceAndMessageIsEmpty(
            int sourceFailureCode)
        {
            var actual = Failure.Create(sourceFailureCode, null);
            var expected = new Failure<int>(sourceFailureCode, EmptyString);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, EmptyString)]
        [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Unknown, TabString)]
        [InlineData(SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.First, EmptyString)]
        [InlineData(SomeFailureCode.Second, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Third, TabString)]
        [InlineData(SomeFailureCode.Second, LowerSomeString)]
        [InlineData(SomeFailureCode.First, SomeString)]
        [InlineData(SomeFailureCode.Third, UpperSomeString)]
        public void Create_SourceFailureMessageIsNotNull_ExpectFailureCodeAndMessageAreEqualToSource(
            SomeFailureCode sourceFailureCode,
            string sourceFailureMessage)
        {
            var actual = Failure.Create(sourceFailureCode, sourceFailureMessage);
            var expected = new Failure<SomeFailureCode>(sourceFailureCode, sourceFailureMessage);

            Assert.Equal(expected, actual);
        }
    }
}