using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Fact]
    public void EqualsOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
    {
        var source = new Failure<decimal>();
        var other = default(Failure<decimal>);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void EqualsOther_SourceIsDefaultAndOtherCodeIsDefaultAndOtherMessageIsNullOrEmpty_ExpectTrue(
        string? otherMessage)
    {
        var source = default(Failure<long>);
        var other = new Failure<long>(0, otherMessage);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void EqualsOther_SourceCodeIsDefaultAndSourceMessageIsNullOrEmptyAndOtherIsDefault_ExpectTrue(
        string? sourceMessage)
    {
        var source = new Failure<StructType>(default, sourceMessage);
        var other = new Failure<StructType>();

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, null, null)]
    [InlineData(SomeFailureCode.Unknown, EmptyString, null)]
    [InlineData(SomeFailureCode.Unknown, null, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.First, LowerSomeString, LowerSomeString)]
    [InlineData(SomeFailureCode.Second, SomeString, SomeString)]
    public void EqualsOther_SourceCodeIsEqualToOtherCodeAndMessagesAreNullOrEmpty_ExpectTrue(
        SomeFailureCode failureCode,
        string? sourceMessage,
        string? otherMessage)
    {
        var source = new Failure<SomeFailureCode>(failureCode, sourceMessage);
        var other = new Failure<SomeFailureCode>(failureCode, otherMessage);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(long.MaxValue, null)]
    [InlineData(Zero, ThreeWhiteSpacesString)]
    [InlineData(Zero, TabString)]
    public void EqualsOther_SourceIsDefaultAndOtherCodeIsNotDefaultOrOtherMessageIsNotEmpty_ExpectFalse(
        long otherCode,
        string? otherMessage)
    {
        var source = new Failure<long>();
        var other = new Failure<long>(otherCode, otherMessage);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Third, null)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    public void EqualsOther_SourceCodeIsNotDefaultOrSourceMessageIsNotEmptyAndOtherIsDefault_ExpectFalse(
        SomeFailureCode sourceCode,
        string? sourceMessage)
    {
        var source = new Failure<SomeFailureCode>(sourceCode, sourceMessage);
        var other = default(Failure<SomeFailureCode>);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(Zero, null, Zero, WhiteSpaceString)]
    [InlineData(Zero, EmptyString, Zero, TabString)]
    [InlineData(Zero, LowerSomeString, Zero, SomeString)]
    [InlineData(PlusFifteen, WhiteSpaceString, PlusFifteen, TabString)]
    [InlineData(Zero, SomeString, MinusFifteen, SomeString)]
    [InlineData(PlusFifteen, UpperSomeString, MinusFifteen, UpperSomeString)]
    public void EqualsOther_SourceCodeIsNotEqualToOtherCodeAndSourceMessageIsNotEqualToOtherMessage_ExpectFalse(
        int sourceCode, string? sourceMessage,
        int otherCode, string? otherMessage)
    {
        var source = new Failure<int>(sourceCode, sourceMessage);
        var other = new Failure<int>(otherCode, otherMessage);

        var actual = source.Equals(other);
        Assert.False(actual);
    }
}
