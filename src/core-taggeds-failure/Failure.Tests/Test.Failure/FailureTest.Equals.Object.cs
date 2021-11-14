using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Fact]
    public void EqualsObject_SourceIsDefaultAndObjIsDefaultFailureSameType_ExpectTrue()
    {
        var source = default(Failure<SomeFailureCode>);
        object? obj = new Failure<SomeFailureCode>();

        var actual = source.Equals(obj);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void EqualsObject_SourceIsDefaultAndObjCodeIsDefaultAndObjMessageIsNullOrEmptyAndTypesAreSame_ExpectTrue(
        string? failureMessage)
    {
        var source = new Failure<long>();
        object? obj = new Failure<long>(default, failureMessage);

        var actual = source.Equals(obj);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void EqualsObject_SourceCodeIsDefaultAndSourceMessageIsNullOrEmptyAndObjIsDefaultAndTypesAreSame_ExpectTrue(
        string? failureMessage)
    {
        var source = new Failure<int>(default, failureMessage);
        object? obj = default(Failure<int>);

        var actual = source.Equals(obj);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(Zero, null, null)]
    [InlineData(Zero, EmptyString, null)]
    [InlineData(Zero, null, EmptyString)]
    [InlineData(Zero, EmptyString, EmptyString)]
    [InlineData(MinusFifteen, LowerSomeString, LowerSomeString)]
    [InlineData(int.MaxValue, SomeString, SomeString)]
    public void EqualsObject_SourceCodeIsEqualToObjCodeAndMessagesAreNullOrEmptyAndTypesAreSame_ExpectTrue(
        int failureCode,
        string? sourceMessage,
        string? objMessage)
    {
        var source = new Failure<int>(failureCode, sourceMessage);
        object? obj = new Failure<int>(failureCode, objMessage);

        var actual = source.Equals(obj);
        Assert.True(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, null)]
    [InlineData(SomeFailureCode.Unknown, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    [InlineData(SomeFailureCode.Unknown, SomeString)]
    [InlineData(SomeFailureCode.First, null)]
    [InlineData(SomeFailureCode.Second, EmptyString)]
    [InlineData(SomeFailureCode.Third, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Third, TabString)]
    [InlineData(SomeFailureCode.Second, LowerSomeString)]
    [InlineData(SomeFailureCode.First, SomeString)]
    public void EqualsObject_ObjIsNull_ExpectFalse(
        SomeFailureCode failureCode,
        string? failureMessage)
    {
        var source = new Failure<SomeFailureCode>(failureCode, failureMessage);

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Fact]
    public void EqualsObject_SourceIsDefaultAndObjIsDefaultFailureNotSameType_ExpectFalse()
    {
        var source = default(Failure<SomeFailureCode>);
        object? obj = default(Failure<int>);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void EqualsObject_SourceIsDefaultAndObjCodeIsDefaultAndObjMessageIsNullOrEmptyAndTypesAreNotSame_ExpectFalse(
        string? failureMessage)
    {
        var source = new Failure<int>();
        object? obj = new Failure<byte>(default, failureMessage);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    public void EqualsObject_SourceCodeIsDefaultAndSourceMessageIsNullOrEmptyAndObjIsDefaultAndTypesAreNotSame_ExpectFalse(
        string? failureMessage)
    {
        var source = new Failure<SomeFailureCode>(default, failureMessage);
        object? obj = default(Failure<long>);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(Zero, null, null)]
    [InlineData(Zero, EmptyString, null)]
    [InlineData(Zero, null, EmptyString)]
    [InlineData(Zero, EmptyString, EmptyString)]
    [InlineData(MinusFifteen, LowerSomeString, LowerSomeString)]
    [InlineData(int.MaxValue, SomeString, SomeString)]
    public void EqualsObject_SourceCodeIsSameAsObjCodeIsDefaultAndMessagesAreNullOrEmptyAndTypesAreNotSame_ExpectFalse(
        int failureCode,
        string? sourceMessage,
        string? objMessage)
    {
        var source = new Failure<int>(failureCode, sourceMessage);
        object? obj = new Failure<long>(failureCode, objMessage);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(PlusFifteen, null)]
    [InlineData(Zero, ThreeWhiteSpacesString)]
    [InlineData(Zero, TabString)]
    public void EqualsObject_SourceIsDefaultAndObjCodeIsNotDefaultOrObjMessageIsNotEmptyAndTypesAreNotSame_ExpectFalse(
        int objCode,
        string? objMessage)
    {
        var source = default(Failure<SomeFailureCode>);
        object? obj = new Failure<int>(objCode, objMessage);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(int.MinValue, null)]
    [InlineData(MinusFifteen, WhiteSpaceString)]
    [InlineData(PlusFifteen, TabString)]
    [InlineData(int.MinValue, SomeString)]
    public void EqualsObject_SourceCodeIsNotDefaultOrSourceMessageIsNotEmptyAndObjIsDefaultAndTypesAreNotSame_ExpectFalse(
        int sourceCode,
        string? sourceMessage)
    {
        var source = new Failure<int>(sourceCode, sourceMessage);
        object? obj = new Failure<long>();

        var actual = source.Equals(obj);
        Assert.False(actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, null, SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, EmptyString, SomeFailureCode.Unknown, TabString)]
    [InlineData(SomeFailureCode.Third, WhiteSpaceString, SomeFailureCode.Third, TabString)]
    [InlineData(SomeFailureCode.Unknown, LowerSomeString, SomeFailureCode.Unknown, SomeString)]
    [InlineData(SomeFailureCode.Second, SomeString, SomeFailureCode.Unknown, SomeString)]
    [InlineData(SomeFailureCode.Third, UpperSomeString, SomeFailureCode.First, UpperSomeString)]
    public void EqualsObject_SourceCodeIsNotEqualToObjCodeAndSourceMessageIsNotEqualToObjMessageAndTypesAreSame_ExpectFalse(
        SomeFailureCode sourceCode, string? sourceMessage,
        SomeFailureCode objCode, string? objMessage)
    {
        var source = new Failure<SomeFailureCode>(sourceCode, sourceMessage);
        object? obj = new Failure<SomeFailureCode>(objCode, objMessage);

        var actual = source.Equals(obj);
        Assert.False(actual);
    }
}
