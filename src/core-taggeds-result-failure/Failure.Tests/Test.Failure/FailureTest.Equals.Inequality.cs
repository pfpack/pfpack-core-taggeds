#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureTest
    {
        [Fact]
        public void Inequality_FailureAIsDefaultAndFailureBIsDefault_ExpectFalse()
        {
            var failureA = default(Failure<int>);
            var failureB = new Failure<int>();

            var actual = failureA != failureB;
            Assert.False(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        public void Inequality_FailureAIsDefaultAndFailureBCodeIsDefaultAndFailueBMessageIsNullOrEmpty_ExpectFalse(
            string? failureMessage)
        {
            var failureA = new Failure<StructType>();
            var failureB = new Failure<StructType>(default, failureMessage);

            var actual = failureA != failureB;
            Assert.False(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        public void Inequality_FailureACodeIsDefaultAndFailueAMessageIsNullOrEmptyAndFailureBIsDefault_ExpectFalse(
            string? failureMessage)
        {
            var failureA = new Failure<decimal>(default, failureMessage);
            var failureB = new Failure<decimal>();

            var actual = failureA != failureB;
            Assert.False(actual);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, null, null)]
        [InlineData(SomeFailureCode.Unknown, EmptyString, null)]
        [InlineData(SomeFailureCode.Unknown, null, EmptyString)]
        [InlineData(SomeFailureCode.Unknown, EmptyString, EmptyString)]
        [InlineData(SomeFailureCode.First, UpperSomeString, UpperSomeString)]
        [InlineData(SomeFailureCode.Third, SomeString, SomeString)]
        public void Inequality_FailureACodeIsSameAsFailureBCodeIsDefaultAndFailueAMessagesAreNullOrEmpty_ExpectFalse(
            SomeFailureCode failueCode,
            string? failureAMessage,
            string? failureBMessage)
        {
            var failureA = new Failure<SomeFailureCode>(failueCode, failureAMessage);
            var failureB = new Failure<SomeFailureCode>(failueCode, failureBMessage);

            var actual = failureA != failureB;
            Assert.False(actual);
        }

        [Theory]
        [InlineData(PlusFifteen, null)]
        [InlineData(Zero, WhiteSpaceString)]
        [InlineData(Zero, TabString)]
        [InlineData(Zero, LowerSomeString)]
        public void Inequality_FailureAIsDefaultAndFailureBCodeIsNotDefaultOrFailueBMessageIsNotEmpty_ExpectTrue(
            int failureBCode,
            string? failureBMessage)
        {
            var failureA = new Failure<int>();
            var failureB = new Failure<int>(failureBCode, failureBMessage);

            var actual = failureA != failureB;
            Assert.True(actual);
        }

        [Theory]
        [InlineData(long.MinValue, null)]
        [InlineData(Zero, WhiteSpaceString)]
        [InlineData(Zero, TabString)]
        [InlineData(Zero, SomeString)]
        [InlineData(long.MinValue, LowerSomeString)]
        public void Inequality_FailureACodeIsNotDefaultOrFailueAMessageIsNotEmptyAndFailureBIsDefault_ExpectTrue(
            long failureACode,
            string? failureAMessage)
        {
            var failureA = new Failure<long>(failureACode, failureAMessage);
            var failureB = new Failure<long>();

            var actual = failureA != failureB;
            Assert.True(actual);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, null, SomeFailureCode.Unknown, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Unknown, EmptyString, SomeFailureCode.Unknown, TabString)]
        [InlineData(SomeFailureCode.Unknown, LowerSomeString, SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.First, WhiteSpaceString, SomeFailureCode.First, TabString)]
        [InlineData(SomeFailureCode.Unknown, SomeString, SomeFailureCode.Second, SomeString)]
        [InlineData(SomeFailureCode.Third, UpperSomeString, SomeFailureCode.First, UpperSomeString)]
        public void Inequality_FailureACodeIsNotEqualFailureBCodeAndFailureAMessageIsNotEqualFailureBMessage_ExpectTrue(
            SomeFailureCode failureACode, string? failureAMessage,
            SomeFailureCode failureBCode, string? failureBMessage)
        {
            var failureA = new Failure<SomeFailureCode>(failureACode, failureAMessage);
            var failureB = new Failure<SomeFailureCode>(failureBCode, failureBMessage);

            var actual = failureA != failureB;
            Assert.True(actual);
        }
    }
}