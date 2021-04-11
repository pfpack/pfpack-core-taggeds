#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureTest
    {
        [Fact]
        public void GetHashCode_FirstIsDefaultAndSecondIsDefault_ExpectHashCodesAreEqual()
        {
            var first = new Failure<decimal>();
            var second = default(Failure<decimal>);

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.Equal(firstHashCode, secondHashCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        public void GetHashCode_FirstIsDefaultAndSecondCodeIsDefaultAndSecondMessageIsNullOrEmpty_ExpectHashCodesAreEqual(
            string? failureMessage)
        {
            var first = new Failure<int>();
            var second = new Failure<int>(default, failureMessage);

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.Equal(firstHashCode, secondHashCode);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        public void GetHashCode_FirstCodeIsDefaultAndFirstMessageIsNullOrEmptyAndSecondIsDefault_ExpectHashCodesAreEqual(
            string? failureMessage)
        {
            var first = new Failure<SomeFailureCode>(SomeFailureCode.Unknown, failureMessage);
            var second = new Failure<SomeFailureCode>();

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.Equal(firstHashCode, secondHashCode);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, null, null)]
        [InlineData(SomeFailureCode.Unknown, EmptyString, null)]
        [InlineData(SomeFailureCode.Unknown, null, EmptyString)]
        [InlineData(SomeFailureCode.Unknown, WhiteSpaceString, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Second, UpperSomeString, UpperSomeString)]
        [InlineData(SomeFailureCode.First, SomeString, SomeString)]
        public void GetHashCode_FirstCodeIsEqualToSecondCodeAndMessagesAreNullOrEmpty_ExpectHashCodesAreEqual(
            SomeFailureCode failureCode,
            string? firstMessage,
            string? secondMessage)
        {
            var first = new Failure<SomeFailureCode>(failureCode, firstMessage);
            var second = new Failure<SomeFailureCode>(failureCode, secondMessage);

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.Equal(firstHashCode, secondHashCode);
        }

        [Theory]
        [InlineData(MinusFifteen, null)]
        [InlineData(PlusFifteen, WhiteSpaceString)]
        [InlineData(PlusFifteen, TabString)]
        [InlineData(MinusFifteen, SomeString)]
        public void GetHashCode_FirstIsDefaultAndSecondCodeIsNotDefaultOrSecondMessageIsNotEmpty_ExpectHashCodesAreNotEqual(
            int secondCode,
            string? secondMessage)
        {
            var first = default(Failure<int>);
            var second = new Failure<int>(secondCode, secondMessage);

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.NotEqual(firstHashCode, secondHashCode);
        }

        [Theory]
        [InlineData(PlusFifteen, null)]
        [InlineData(Zero, WhiteSpaceString)]
        [InlineData(Zero, TabString)]
        public void GetHashCode_FirstCodeIsNotDefaultOrFirstMessageIsNotEmptyAndSecondIsDefault_ExpectHashCodesAreNotEqual(
            int firstCode,
            string? firstMessage)
        {
            var first = new Failure<int>(firstCode, firstMessage);
            var second = new Failure<int>();

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.NotEqual(firstHashCode, secondHashCode);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, null, SomeFailureCode.Unknown, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Unknown, LowerSomeString, SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.Second, WhiteSpaceString, SomeFailureCode.Second, TabString)]
        [InlineData(SomeFailureCode.First, SomeString, SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.Second, UpperSomeString, SomeFailureCode.First, UpperSomeString)]
        public void GetHashCode_FirstCodeIsNotEqualToSecondOneAndFirstMessageIsNotEqualToSecondOne_ExpectHashCodesAreNotEqual(
            SomeFailureCode firstCode, string? firstMessage,
            SomeFailureCode secondCode, string? secondMessage)
        {
            var first = new Failure<SomeFailureCode>(firstCode, firstMessage);
            var second = new Failure<SomeFailureCode>(secondCode, secondMessage);

            var firstHashCode = first.GetHashCode();
            var secondHashCode = second.GetHashCode();

            Assert.NotEqual(firstHashCode, secondHashCode);
        }
    }
}