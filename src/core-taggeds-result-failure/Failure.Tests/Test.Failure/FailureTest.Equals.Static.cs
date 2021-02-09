#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureTest
    {
        [Fact]
        public void EqualsStatic_FailureAIsDefaultAndFailureBIsDefault_ExpectTrue()
        {
            var failureA = default(Failure<SomeFailureCode>);
            var failureB = new Failure<SomeFailureCode>();

            var actual = Failure<SomeFailureCode>.Equals(failureA, failureB);
            Assert.True(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        public void EqualsStatic_FailureAIsDefaultAndFailureBCodeIsDefaultAndFailueBMessageIsNullOrEmpty_ExpectTrue(
            string? failureMessage)
        {
            var failureA = new Failure<int>();
            var failureB = new Failure<int>(default, failureMessage);

            var actual = Failure<int>.Equals(failureA, failureB);
            Assert.True(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        public void EqualsStatic_FailureACodeIsDefaultAndFailueAMessageIsNullOrEmptyAndFailureBIsDefault_ExpectTrue(
            string? failureMessage)
        {
            var failureA = new Failure<SomeFailureCode>(SomeFailureCode.Unknown, failureMessage);
            var failureB = default(Failure<SomeFailureCode>);

            var actual = Failure<SomeFailureCode>.Equals(failureA, failureB);
            Assert.True(actual);
        }

        [Theory]
        [InlineData(Zero, null, null)]
        [InlineData(Zero, EmptyString, null)]
        [InlineData(Zero, null, EmptyString)]
        [InlineData(Zero, EmptyString, EmptyString)]
        [InlineData(PlusFifteen, LowerSomeString, LowerSomeString)]
        [InlineData(MinusFifteen, SomeString, SomeString)]
        public void EqualsStatic_FailureACodeIsSameAsFailureBCodeIsDefaultAndFailueAMessagesAreNullOrEmpty_ExpectTrue(
            int failueCode,
            string? failureAMessage,
            string? failureBMessage)
        {
            var failureA = new Failure<int>(failueCode, failureAMessage);
            var failureB = new Failure<int>(failueCode, failureBMessage);

            var actual = Failure<int>.Equals(failureA, failureB);
            Assert.True(actual);
        }

        [Theory]
        [InlineData(SomeFailureCode.First, null)]
        [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Unknown, TabString)]
        public void EqualsStatic_FailureAIsDefaultAndFailureBCodeIsNotDefaultOrFailueBMessageIsNotEmpty_ExpectFalse(
            SomeFailureCode failureBCode,
            string? failureBMessage)
        {
            var failureA = new Failure<SomeFailureCode>();
            var failureB = new Failure<SomeFailureCode>(failureBCode, failureBMessage);

            var actual = Failure<SomeFailureCode>.Equals(failureA, failureB);
            Assert.False(actual);
        }

        [Theory]
        [InlineData(PlusFifteen, null)]
        [InlineData(Zero, WhiteSpaceString)]
        [InlineData(Zero, TabString)]
        public void EqualsStatic_FailureACodeIsNotDefaultOrFailueAMessageIsNotEmptyAndFailureBIsDefault_ExpectFalse(
            int failureACode,
            string? failureAMessage)
        {
            var failureA = new Failure<int>(failureACode, failureAMessage);
            var failureB = new Failure<int>();

            var actual = Failure<int>.Equals(failureA, failureB);
            Assert.False(actual);
        }

        [Theory]
        [InlineData(SomeFailureCode.Unknown, null, SomeFailureCode.Unknown, WhiteSpaceString)]
        [InlineData(SomeFailureCode.Unknown, EmptyString, SomeFailureCode.Unknown, TabString)]
        [InlineData(SomeFailureCode.Unknown, LowerSomeString, SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.Second, WhiteSpaceString, SomeFailureCode.Second, TabString)]
        [InlineData(SomeFailureCode.First, SomeString, SomeFailureCode.Unknown, SomeString)]
        [InlineData(SomeFailureCode.Second, UpperSomeString, SomeFailureCode.First, UpperSomeString)]
        public void EqualsStatic_FailureACodeIsNotEqualFailureBCodeAndFailureAMessageIsNotEqualFailureBMessage_ExpectFalse(
            SomeFailureCode failureACode, string? failureAMessage,
            SomeFailureCode failureBCode, string? failureBMessage)
        {
            var failureA = new Failure<SomeFailureCode>(failureACode, failureAMessage);
            var failureB = new Failure<SomeFailureCode>(failureBCode, failureBMessage);

            var actual = Failure<SomeFailureCode>.Equals(failureA, failureB);
            Assert.False(actual);
        }
    }
}