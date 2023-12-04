using System;
using PrimeFuncPack.UnitTest;
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
    public static void Deconstruct_SourceFailureMessageIsNull_ExpectFailureCodeIsEqualToSourceAndMessageIsEmpty(
        int sourceFailureCode)
    {
        var source = new Failure<int>(sourceFailureCode, null);

        var (actualFailureCode, actualFailureMessage) = source;

        AssertEqualFailures(
            (source.FailureCode, source.FailureMessage, null),
            (actualFailureCode, actualFailureMessage, null));
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
    public static void Deconstruct_SourceFailureMessageIsNotNull_ExpectFailureCodeAndMessageAreEqualToSource(
        EnumType sourceFailureCode, string sourceFailureMessage)
    {
        var source = new Failure<EnumType>(sourceFailureCode, sourceFailureMessage);

        var (actualFailureCode, actualFailureMessage) = source;

        AssertEqualFailures(
            (source.FailureCode, source.FailureMessage, null),
            (actualFailureCode, actualFailureMessage, null));
    }
}
