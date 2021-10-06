#nullable enable

using System;
using System.Globalization;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;
using static System.FormattableString;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureTest
    {
        [Fact]
        public void ToString_FailureIsDefault_ExpectResultStringContainsDefaultFailureCode()
        {
            var failure = default(Failure<SomeFailureCode>);
            var actual = failure.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "Failure[{0}]:{{ FailureCode: {1}, FailureMessage: \"{2}\" }}",
                typeof(SomeFailureCode),
                SomeFailureCode.Unknown,
                string.Empty);

            Assert.Contains(expected, actual, StringComparison.InvariantCulture);
        }

        [Theory]
        [InlineData(Zero, null)]
        [InlineData(PlusFifteen, null)]
        [InlineData(Zero, EmptyString)]
        [InlineData(MinusFifteen, EmptyString)]
        [InlineData(Zero, SomeString)]
        [InlineData(int.MaxValue, LowerSomeString)]
        public void ToString_FailureIsNotDefault_ExpectResultStringContainsSourceFailureCode(
            int failureCode,
            string? failureMessage)
        {
            var sourceFailure = new Failure<int>(failureCode, failureMessage);
            var actual = sourceFailure.ToString();

            var expectedFailureCodeString = Invariant($"{failureCode}");
            Assert.Contains(expectedFailureCodeString, actual, StringComparison.InvariantCulture);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
        [InlineData(SomeFailureCode.First, TabString)]
        [InlineData(SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.Second, LowerSomeString)]
        [InlineData(SomeFailureCode.Third, UpperSomeString)]
        public void ToString_FailureMessageIsNotEmpty_ExpectResultStringContainsSourceFailureMessage(
            SomeFailureCode failureCode,
            string failureMessage)
        {
            var sourceFailure = new Failure<SomeFailureCode>(failureCode, failureMessage);
            var actual = sourceFailure.ToString();

            Assert.Contains(failureMessage, actual, StringComparison.InvariantCulture);
        }
    }
}