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
        var failure = default(Failure<EnumType>);
        var actual = failure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": null }}",
            typeof(EnumType).Name,
            EnumType.Zero,
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
    [InlineData(EnumType.Zero, null, EmptyString)]
    [InlineData(EnumType.One, EmptyString, EmptyString)]
    [InlineData(EnumType.Zero, SomeString, SomeString)]
    public static void ToString_SourceExceptionIsNotNull(
        EnumType failureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new InvalidOperationException("Some error message");

        var sourceFailure = new Failure<EnumType>(failureCode, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var actual = sourceFailure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure<{0}>:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\", \"SourceException\": \"{3}\" }}",
            typeof(EnumType).Name,
            failureCode,
            expectedFailureMessage,
            sourceException);

        Assert.Equal(expected, actual);
    }
}
