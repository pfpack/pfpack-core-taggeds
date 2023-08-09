using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void MapFailureCode_MapFailureCodeIsNull_ExpectArgumentNullException(
        bool isNotDefault)
    {
        var source = isNotDefault ? new Failure<SomeFailureCode>(SomeFailureCode.First, SomeString) : default;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.MapFailureCode((Func<SomeFailureCode, int>)null!));
        Assert.Equal("mapFailureCode", ex.ParamName);
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown)]
    [InlineData(SomeFailureCode.First)]
    [InlineData(SomeFailureCode.Second)]
    [InlineData(SomeFailureCode.Third)]
    public static void MapFailureCode_SourceIsDefault_ExpectFailureCodeIsMappedAndFailureMessageIsEmpty(
        SomeFailureCode mappedFailureCode)
    {
        var source = default(Failure<int>);

        var actual = source.MapFailureCode(_ => mappedFailureCode);

        AssertEqualFailures(
            (mappedFailureCode, EmptyString, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(int.MinValue, EmptyString, EmptyString)]
    [InlineData(MinusFifteen, SomeString, SomeString)]
    [InlineData(Zero, null, EmptyString)]
    public static void MapFailureCode_SourceExceptionIsNull_ExpectFailureCodeIsMappedAndSourceExceptionIsNull(
        int mappedFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var source = new Failure<decimal>(decimal.One, sourceFailureMessage);

        var actual = source.MapFailureCode(_ => mappedFailureCode);

        AssertEqualFailures(
            (mappedFailureCode, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(SomeFailureCode.Unknown, null, EmptyString)]
    [InlineData(SomeFailureCode.First, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.Second, SomeString, SomeString)]
    public static void MapFailureCode_SourceExceptionIsNotNull_ExpectFailureCodeIsMappedAndSourceExceptionIsSame(
        SomeFailureCode mappedFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception("Some error message");

        var source = new Failure<int>(MinusFifteen, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var actual = source.MapFailureCode(_ => mappedFailureCode);

        AssertEqualFailures(
            (mappedFailureCode, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
