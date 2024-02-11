using System;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureExtensionsTest
{
    [Theory]
    [InlineData(null, EmptyString)]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(SomeString, SomeString)]
    public static void ToFailureUnitFailureCode_SourceExceptionIsNull_ExpectActualExceptionIsNull(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        Exception? sourceException = null;
        var actual = sourceException.ToFailure(sourceFailureMessage);

        AssertEqualFailures(
            (Unit.Value, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(null, EmptyString)]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(SomeString, SomeString)]
    public static void ToFailureUnitFailureCode_SourceExceptionIsNotNull_ExpectActualExceptionIsSame(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new InvalidOperationException(
            message: "Some error message",
            innerException: new Exception("Some inner error text"));

        var actual = sourceException.ToFailure(sourceFailureMessage);

        AssertEqualFailures(
            (Unit.Value, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}