using System;
using System.Globalization;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Fact]
    public void ToString_FailureIsDefault()
    {
        var failure = default(Failure<SomeFailureCode>);
        var actual = failure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure[{0}]:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\" }}",
            typeof(SomeFailureCode),
            SomeFailureCode.Unknown,
            string.Empty);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Zero, null)]
    [InlineData(PlusFifteen, null)]
    [InlineData(Zero, EmptyString)]
    [InlineData(MinusFifteen, EmptyString)]
    [InlineData(Zero, SomeString)]
    [InlineData(int.MaxValue, LowerSomeString)]
    public void ToString_FailureIsNotDefault(
        int failureCode,
        string? failureMessage)
    {
        var sourceFailure = new Failure<int>(failureCode, failureMessage);
        var actual = sourceFailure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure[{0}]:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\" }}",
            typeof(int),
            failureCode,
            failureMessage);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, WhiteSpaceString)]
    [InlineData(SomeFailureCode.First, TabString)]
    [InlineData(SomeFailureCode.Unknown, SomeString)]
    [InlineData(SomeFailureCode.Second, LowerSomeString)]
    [InlineData(SomeFailureCode.Third, UpperSomeString)]
    public void ToString_FailureMessageIsNotEmpty(
        SomeFailureCode failureCode,
        string failureMessage)
    {
        var sourceFailure = new Failure<SomeFailureCode>(failureCode, failureMessage);
        var actual = sourceFailure.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Failure[{0}]:{{ \"FailureCode\": {1}, \"FailureMessage\": \"{2}\" }}",
            typeof(SomeFailureCode),
            failureCode,
            failureMessage);

        Assert.Equal(expected, actual);
    }
}
