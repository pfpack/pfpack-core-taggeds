#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureStaticTest
    {
        [Fact]
        public void CreateUnitFailureCode_SourceFailureMessageIsNull_ExpactFailureCodeIsUnitAndFailureMessageIsEmpty()
        {
            var actual = Failure.Create(null);
            var expected = new Failure<Unit>(Unit.Value, EmptyString);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(EmptyString)]
        [InlineData(WhiteSpaceString)]
        [InlineData(TabString)]
        [InlineData(LowerSomeString)]
        [InlineData(SomeString)]
        public void CreateUnitFailureCode_SourceFailureMessageIsNotNull_ExpactFailureCodeIsUnitAndMessageIsSameAsSource(
            string sourceFailureMessage)
        {
            var actual = Failure.Create(sourceFailureMessage);
            var expected = new Failure<Unit>(Unit.Value, sourceFailureMessage);

            Assert.Equal(expected, actual);
        }
    }
}