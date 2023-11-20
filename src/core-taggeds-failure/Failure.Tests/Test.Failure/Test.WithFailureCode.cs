using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [InlineData(null, TestData.EmptyString)]
    [InlineData(TestData.EmptyString, TestData.EmptyString)]
    [InlineData(TestData.SomeString, TestData.SomeString)]
    public static void WithFailureCodeNext_SourceExceptionIsNull_ExpectFailureCodeIsNextAndFailureMessageIsSame(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var source = new Failure<int>(TestData.PlusFifteen, sourceFailureMessage);
        var actual = source.WithFailureCode(byte.MaxValue);

        AssertEqualFailures(
            (byte.MaxValue, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(null, TestData.EmptyString)]
    [InlineData(TestData.EmptyString, TestData.EmptyString)]
    [InlineData(TestData.SomeString, TestData.SomeString)]
    public static void WithFailureCodeNext_SourceExceptionIsNotNull_ExpectFailureCodeIsNextAndFailureMessageIsSameAndSourceExceptionIsSame(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception("Some exception message");

        var source = new Failure<DateTimeKind>(DateTimeKind.Local, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var actual = source.WithFailureCode(UriKind.Absolute);

        AssertEqualFailures(
            (UriKind.Absolute, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(null, TestData.EmptyString)]
    [InlineData(TestData.EmptyString, TestData.EmptyString)]
    [InlineData(TestData.SomeString, TestData.SomeString)]
    public static void WithFailureCode_SourceExceptionIsNull_ExpectFailureCodeIsNextAndFailureMessageIsSame(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var source = new Failure<UriKind>(UriKind.Absolute, sourceFailureMessage);
        var actual = source.WithFailureCode(UriKind.Relative);

        AssertEqualFailures(
            (UriKind.Relative, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(null, TestData.EmptyString)]
    [InlineData(TestData.EmptyString, TestData.EmptyString)]
    [InlineData(TestData.SomeString, TestData.SomeString)]
    public static void WithFailureCode_SourceExceptionIsNotNull_ExpectFailureCodeIsNextAndFailureMessageIsSameAndSourceExceptionIsSame(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception("Some error message");

        var source = new Failure<decimal>(decimal.MaxValue, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var actual = source.WithFailureCode(decimal.One);

        AssertEqualFailures(
            (decimal.One, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}