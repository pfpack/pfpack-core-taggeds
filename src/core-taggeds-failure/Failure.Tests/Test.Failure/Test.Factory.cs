using System;
using PrimeFuncPack.UnitTest;
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
    [InlineData(EnumType.Zero, EmptyString)]
    [InlineData(EnumType.Zero, WhiteSpaceString)]
    [InlineData(EnumType.Zero, TabString)]
    [InlineData(EnumType.Zero, SomeString)]
    [InlineData(EnumType.One, EmptyString)]
    [InlineData(EnumType.Two, WhiteSpaceString)]
    [InlineData(EnumType.Three, TabString)]
    [InlineData(EnumType.Two, LowerSomeString)]
    [InlineData(EnumType.One, SomeString)]
    [InlineData(EnumType.Three, UpperSomeString)]
    public static void Constructor_SourceFailureMessageIsNotNull_ExpectFailureCodeAndMessageAreEqualToSource(
        EnumType sourceFailureCode,
        string sourceFailureMessage)
    {
        var actual = new Failure<EnumType>(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, sourceFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
