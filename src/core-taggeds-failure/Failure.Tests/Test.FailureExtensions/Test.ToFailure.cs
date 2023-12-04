using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureExtensionsTest
{
    [Theory]
    [InlineData(EnumType.One, null, EmptyString)]
    [InlineData(EnumType.Two, EmptyString, EmptyString)]
    [InlineData(EnumType.Zero, SomeString, SomeString)]
    public static void ToFailure_SourceExceptionIsNull_ExpectActualExceptionIsNull(
        EnumType sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        Exception? sourceException = null;
        var actual = sourceException.ToFailure(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(EnumType.One, null, EmptyString)]
    [InlineData(EnumType.Two, EmptyString, EmptyString)]
    [InlineData(EnumType.Zero, SomeString, SomeString)]
    public static void ToFailure_SourceExceptionIsNull_ExpectActualExceptionIsSame(
        EnumType sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception("Some Exception Message");
        var actual = sourceException.ToFailure(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}