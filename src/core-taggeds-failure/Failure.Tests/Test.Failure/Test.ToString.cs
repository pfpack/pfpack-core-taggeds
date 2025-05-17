using System;
using System.Globalization;
using PrimeFuncPack.UnitTest;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Fact]
    public static void ToString_FailureIsDefault()
    {
        var sourceFailure = default(Failure<EnumType>);

        var actual = sourceFailure.ToString();

        var expected = InnerBuildExpectedFailureToString<EnumType>(
            failureCodeString: EnumType.Zero.ToString(),
            failureMessage: string.Empty);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Zero, null, EmptyString)]
    [InlineData(Zero, EmptyString, EmptyString)]
    [InlineData(Zero, SomeString, SomeString)]
    public static void ToString_SourceExceptionIsNull(
        int failureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceFailure = new Failure<int>(failureCode, sourceFailureMessage)
        {
            SourceException = null
        };

        var actual = sourceFailure.ToString();

        var expected = InnerBuildExpectedFailureToString<int>(
            failureCodeString: failureCode.ToString(CultureInfo.InvariantCulture),
            failureMessage: expectedFailureMessage);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(EnumType.Zero, null, EmptyString)]
    [InlineData(EnumType.One, EmptyString, EmptyString)]
    [InlineData(EnumType.Zero, SomeString, SomeString)]
    public static void ToString_SourceExceptionIsNotNull(
        EnumType failureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceFailure = new Failure<EnumType>(failureCode, sourceFailureMessage)
        {
            SourceException = new StubToStringException()
        };

        var actual = sourceFailure.ToString();

        var expected = InnerBuildExpectedFailureToString<EnumType>(
            failureCodeString: failureCode.ToString(),
            failureMessage: expectedFailureMessage,
            sourceExceptionToString: StubToStringException.ToStringResult);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(null, EmptyString)]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(SomeString, SomeString)]
    public static void ToString_SourceExceptionIsNotNull_Formattable(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var failureCode = new StubToStringStructFormattable();

        var sourceFailure = new Failure<StubToStringStructFormattable>(failureCode, sourceFailureMessage)
        {
            SourceException = new StubToStringFormattableException()
        };

        var actual = sourceFailure.ToString();

        var expected = InnerBuildExpectedFailureToString<StubToStringStructFormattable>(
            failureCodeString: failureCode.ToString(null, CultureInfo.InvariantCulture),
            failureMessage: expectedFailureMessage,
            sourceExceptionToString: StubToStringFormattableException.ToStringResultFormatted);

        Assert.Equal(expected, actual);
    }

    private static string InnerBuildExpectedFailureToString<TFailureCode>(
        string failureCodeString,
        string failureMessage)
        where TFailureCode : struct
        =>
        string.Format(
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": null }}",
            typeof(TFailureCode).Name,
            failureCodeString,
            failureMessage);

    private static string InnerBuildExpectedFailureToString<TFailureCode>(
        string failureCodeString,
        string failureMessage,
        string? sourceExceptionToString)
        where TFailureCode : struct
        =>
        string.Format(
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": \"{3}\" }}",
            typeof(TFailureCode).Name,
            failureCodeString,
            failureMessage,
            sourceExceptionToString);
}
