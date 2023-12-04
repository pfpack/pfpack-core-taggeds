using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Theory]
    [InlineData(EnumType.One, null, EmptyString)]
    [InlineData(EnumType.Two, EmptyString, EmptyString)]
    [InlineData(EnumType.Zero, SomeString, SomeString)]
    public static void CreateWithSourceException_SourceExceptionIsNull_ExpectActualExceptionIsNull(
        EnumType sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var actual = Failure.Create(sourceFailureCode, sourceFailureMessage, null);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(EnumType.One, null, EmptyString)]
    [InlineData(EnumType.Two, EmptyString, EmptyString)]
    [InlineData(EnumType.Zero, SomeString, SomeString)]
    public static void CreateWithSourceException_SourceExceptionIsNull_ExpectActualExceptionIsSame(
        EnumType sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new InvalidOperationException("Some Exception Message");
        var actual = Failure.Create(sourceFailureCode, sourceFailureMessage, sourceException);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
