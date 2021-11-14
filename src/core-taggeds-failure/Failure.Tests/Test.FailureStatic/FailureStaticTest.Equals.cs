using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Fact]
    public void Equals_FailureAIsDefaultAndFailureBIsDefault_ExpectTrue()
    {
        var failureA = default(Failure<int>);
        var failureB = new Failure<int>();

        var actual = Failure.Equals(failureA, failureB);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void Equals_FailureAIsDefaultAndFailureBCodeIsDefaultAndFailureBMessageIsNullOrEmpty_ExpectTrue(
        string? failureMessage)
    {
        var failureA = default(Failure<SomeFailureCode>);
        var failureB = new Failure<SomeFailureCode>(default, failureMessage);

        var actual = Failure.Equals(failureA, failureB);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void Equals_FailureACodeIsDefaultAndFailureAMessageIsNullOrEmptyAndFailureBIsDefault_ExpectTrue(
        string? failureMessage)
    {
        var failureA = new Failure<byte>(default, failureMessage);
        var failureB = new Failure<byte>();

        var actual = Failure.Equals(failureA, failureB);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(Zero, null, null)]
    [InlineData(Zero, EmptyString, null)]
    [InlineData(Zero, null, EmptyString)]
    [InlineData(Zero, EmptyString, EmptyString)]
    [InlineData(PlusFifteen, LowerSomeString, LowerSomeString)]
    [InlineData(MinusFifteen, SomeString, SomeString)]
    public void Equals_FailureACodeIsEqualToFailureBCodeAndMessagesAreNullOrEmpty_ExpectTrue(
        int failureCode,
        string? failureAMessage,
        string? failureBMessage)
    {
        var failureA = new Failure<int>(failureCode, failureAMessage);
        var failureB = new Failure<int>(failureCode, failureBMessage);

        var actual = Failure.Equals(failureA, failureB);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.First, null)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    public void Equals_FailureAIsDefaultAndFailureBCodeIsNotDefaultOrFailureBMessageIsNotEmpty_ExpectFalse(
        SomeFailureCode failureBCode,
        string? failureBMessage)
    {
        var failureA = new Failure<SomeFailureCode>();
        var failureB = new Failure<SomeFailureCode>(failureBCode, failureBMessage);

        var actual = Failure.Equals(failureA, failureB);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Third, null)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    [InlineData(SomeFailureCode.Unknown, SomeString)]
    [InlineData(SomeFailureCode.First, SomeString)]
    public void Equals_FailureACodeIsNotDefaultOrFailureAMessageIsNotEmptyAndFailureBIsDefault_ExpectFalse(
        SomeFailureCode failureACode,
        string? failureAMessage)
    {
        var failureA = new Failure<SomeFailureCode>(failureACode, failureAMessage);
        var failureB = default(Failure<SomeFailureCode>);

        var actual = Failure.Equals(failureA, failureB);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(Zero, null, Zero, WhiteSpaceString)]
    [InlineData(Zero, EmptyString, Zero, TabString)]
    [InlineData(Zero, LowerSomeString, Zero, SomeString)]
    [InlineData(PlusFifteen, WhiteSpaceString, PlusFifteen, TabString)]
    [InlineData(MinusFifteen, SomeString, Zero, SomeString)]
    [InlineData(int.MaxValue, UpperSomeString, PlusFifteen, UpperSomeString)]
    public void Equals_FailureACodeIsNotEqualToFailureBCodeAndFailureAMessageIsNotEqualToFailureBMessage_ExpectFalse(
        int failureACode, string? failureAMessage,
        int failureBCode, string? failureBMessage)
    {
        var failureA = new Failure<int>(failureACode, failureAMessage);
        var failureB = new Failure<int>(failureBCode, failureBMessage);

        var actual = Failure.Equals(failureA, failureB);
        Assert.False(actual);
    }
}
