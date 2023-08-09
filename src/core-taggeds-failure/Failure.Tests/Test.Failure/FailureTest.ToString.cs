using System;
using System.Globalization;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Fact]
    public static void ToString_FailureIsDefault()
    {
        var failure = default(Failure<SomeFailureCode>);
        var actual = failure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": null }}",
            typeof(SomeFailureCode).Name,
            SomeFailureCode.Unknown,
            string.Empty);

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

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": null }}",
            typeof(int).Name,
            failureCode,
            expectedFailureMessage);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, null, EmptyString)]
    [InlineData(SomeFailureCode.First, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, SomeString, SomeString)]
    public static void ToString_SourceExceptionIsNotNull(
        SomeFailureCode failureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new InvalidOperationException("Some error message");

        var sourceFailure = new Failure<SomeFailureCode>(failureCode, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var actual = sourceFailure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": \"{3}\" }}",
            typeof(SomeFailureCode).Name,
            failureCode,
            expectedFailureMessage,
            sourceException.ToString());

        Assert.Equal(expected, actual);
    }
}
