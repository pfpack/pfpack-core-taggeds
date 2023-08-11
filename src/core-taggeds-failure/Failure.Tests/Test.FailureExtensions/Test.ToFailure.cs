using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureExtensionsTest
{
    [Theory]
    [InlineData(SomeFailureCode.First, null, EmptyString)]
    [InlineData(SomeFailureCode.Second, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, SomeString, SomeString)]
    public static void ToFailure_SourceExceptionIsNull_ExpectActualExceptionIsNull(
        SomeFailureCode sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        Exception? sourceException = null;
        var actual = sourceException.ToFailure(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(SomeFailureCode.First, null, EmptyString)]
    [InlineData(SomeFailureCode.Second, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, SomeString, SomeString)]
    public static void ToFailure_SourceExceptionIsNull_ExpectActualExceptionIsSame(
        SomeFailureCode sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception("Some Exception Message");
        var actual = sourceException.ToFailure(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}