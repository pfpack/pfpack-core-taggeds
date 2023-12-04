using System;
using PrimeFuncPack.UnitTest;
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
        var source = isNotDefault ? new Failure<EnumType>(EnumType.One, SomeString) : default;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.MapFailureCode((Func<EnumType, int>)null!));
        Assert.Equal("mapFailureCode", ex.ParamName);
    }

    [Theory]
    [InlineData(EnumType.Zero)]
    [InlineData(EnumType.One)]
    [InlineData(EnumType.Two)]
    [InlineData(EnumType.Three)]
    public static void MapFailureCode_SourceIsDefault_ExpectFailureCodeIsMappedAndFailureMessageIsEmpty(
        EnumType mappedFailureCode)
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
    [InlineData(EnumType.Zero, null, EmptyString)]
    [InlineData(EnumType.One, EmptyString, EmptyString)]
    [InlineData(EnumType.Two, SomeString, SomeString)]
    public static void MapFailureCode_SourceExceptionIsNotNull_ExpectFailureCodeIsMappedAndSourceExceptionIsSame(
        EnumType mappedFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
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
