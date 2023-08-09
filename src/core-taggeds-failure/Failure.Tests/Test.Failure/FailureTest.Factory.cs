using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(MinusFifteen)]
    [InlineData(Zero)]
    [InlineData(PlusFifteen)]
    [InlineData(int.MaxValue)]
    public static void Constructor_SourceFailureMessageIsNull_ExpectFailureCodeIsEqualToSourceAndMessageIsEmpty(
        int sourceFailureCode)
    {
        var actual = new Failure<int>(sourceFailureCode, null);

        AssertEqualFailures(
            (sourceFailureCode, EmptyString, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Unknown, TabString)]
    [InlineData(SomeFailureCode.Unknown, SomeString)]
    [InlineData(SomeFailureCode.First, EmptyString)]
    [InlineData(SomeFailureCode.Second, WhiteSpaceString)]
    [InlineData(SomeFailureCode.Third, TabString)]
    [InlineData(SomeFailureCode.Second, LowerSomeString)]
    [InlineData(SomeFailureCode.First, SomeString)]
    [InlineData(SomeFailureCode.Third, UpperSomeString)]
    public static void Constructor_SourceFailureMessageIsNotNull_ExpectFailureCodeAndMessageAreEqualToSource(
        SomeFailureCode sourceFailureCode,
        string sourceFailureMessage)
    {
        var actual = new Failure<SomeFailureCode>(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, sourceFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
