using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Fact]
    public void Equality_FailureAIsDefaultAndFailureBIsDefault_ExpectTrue()
    {
        var failureA = new Failure<StructType>();
        var failureB = default(Failure<StructType>);

        var actual = failureA == failureB;
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void Equality_FailureAIsDefaultAndFailureBCodeIsDefaultAndFailureBMessageIsNullOrEmpty_ExpectTrue(
        string? failureMessage)
    {
        var failureA = new Failure<double>();
        var failureB = new Failure<double>(default, failureMessage);

        var actual = failureA == failureB;
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void Equality_FailureACodeIsDefaultAndFailureAMessageIsNullOrEmptyAndFailureBIsDefault_ExpectTrue(
        string? failureMessage)
    {
        var failureA = new Failure<byte>(default, failureMessage);
        var failureB = new Failure<byte>();

        var actual = failureA == failureB;
        Assert.True(actual);
    }

    [Theory]
    [InlineData(Zero, null, null)]
    [InlineData(Zero, EmptyString, null)]
    [InlineData(Zero, null, EmptyString)]
    [InlineData(Zero, EmptyString, EmptyString)]
    [InlineData(byte.MinValue, UpperSomeString, UpperSomeString)]
    [InlineData(byte.MaxValue, SomeString, SomeString)]
    public void Equality_FailureACodeIsEqualToFailureBCodeAndMessagesAreNullOrEmpty_ExpectTrue(
        byte failureCode,
        string? failureAMessage,
        string? failureBMessage)
    {
        var failureA = new Failure<byte>(failureCode, failureAMessage);
        var failureB = new Failure<byte>(failureCode, failureBMessage);

        var actual = failureA == failureB;
        Assert.True(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Third, null)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    [InlineData(SomeFailureCode.Unknown, LowerSomeString)]
    public void Equality_FailureAIsDefaultAndFailureBCodeIsNotDefaultOrFailureBMessageIsNotEmpty_ExpectFalse(
        SomeFailureCode failureBCode,
        string? failureBMessage)
    {
        var failureA = new Failure<SomeFailureCode>();
        var failureB = new Failure<SomeFailureCode>(failureBCode, failureBMessage);

        var actual = failureA == failureB;
        Assert.False(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Second, null)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    public void Equality_FailureACodeIsNotDefaultOrFailureAMessageIsNotEmptyAndFailureBIsDefault_ExpectFalse(
        SomeFailureCode failureACode,
        string? failureAMessage)
    {
        var failureA = new Failure<SomeFailureCode>(failureACode, failureAMessage);
        var failureB = default(Failure<SomeFailureCode>);

        var actual = failureA == failureB;
        Assert.False(actual);
    }

    [Theory]
    [InlineData(Zero, null, Zero, WhiteSpaceString)]
    [InlineData(Zero, EmptyString, Zero, TabString)]
    [InlineData(Zero, LowerSomeString, Zero, SomeString)]
    [InlineData(PlusFifteen, WhiteSpaceString, PlusFifteen, TabString)]
    [InlineData(Zero, SomeString, int.MaxValue, SomeString)]
    [InlineData(int.MinValue, UpperSomeString, MinusFifteen, UpperSomeString)]
    public void Equality_FailureACodeIsNotEqualToFailureBCodeAndFailureAMessageIsNotEqualToFailureBMessage_ExpectFalse(
        int failureACode, string? failureAMessage,
        int failureBCode, string? failureBMessage)
    {
        var failureA = new Failure<int>(failureACode, failureAMessage);
        var failureB = new Failure<int>(failureBCode, failureBMessage);

        var actual = failureA == failureB;
        Assert.False(actual);
    }
}
