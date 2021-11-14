using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

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
    public void Inequality_FailureAIsDefaultAndFailureBCodeIsDefaultAndFailureBMessageIsNullOrEmpty_ExpectFalse(
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
    public void Inequality_FailureACodeIsDefaultAndFailureAMessageIsNullOrEmptyAndFailureBIsDefault_ExpectFalse(
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
    public void Inequality_FailureACodeIsEqualToFailureBCodeAndMessagesAreNullOrEmpty_ExpectFalse(
        SomeFailureCode failureCode,
        string? failureAMessage,
        string? failureBMessage)
    {
        var failureA = new Failure<SomeFailureCode>(failureCode, failureAMessage);
        var failureB = new Failure<SomeFailureCode>(failureCode, failureBMessage);

        var actual = failureA != failureB;
        Assert.False(actual);
    }

    [Theory]
    [InlineData(PlusFifteen, null)]
    [InlineData(Zero, WhiteSpaceString)]
    [InlineData(Zero, TabString)]
    [InlineData(Zero, LowerSomeString)]
    public void Inequality_FailureAIsDefaultAndFailureBCodeIsNotDefaultOrFailureBMessageIsNotEmpty_ExpectTrue(
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
    public void Inequality_FailureACodeIsNotDefaultOrFailureAMessageIsNotEmptyAndFailureBIsDefault_ExpectTrue(
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
    public void Inequality_FailureACodeIsNotEqualToFailureBCodeAndFailureAMessageIsNotEqualToFailureBMessage_ExpectTrue(
        SomeFailureCode failureACode, string? failureAMessage,
        SomeFailureCode failureBCode, string? failureBMessage)
    {
        var failureA = new Failure<SomeFailureCode>(failureACode, failureAMessage);
        var failureB = new Failure<SomeFailureCode>(failureBCode, failureBMessage);

        var actual = failureA != failureB;
        Assert.True(actual);
    }
}
