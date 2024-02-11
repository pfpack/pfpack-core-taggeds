using System;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Theory]
    [InlineData(null, EmptyString)]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(SomeString, SomeString)]
    public static void CreateUnitFailureCodeWithSourceException_SourceExceptionIsNull_ExpectActualExceptionIsNull(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var actual = Failure.Create(sourceFailureMessage, null);

        AssertEqualFailures(
            (Unit.Value, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }

    [Theory]
    [InlineData(null, EmptyString)]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(SomeString, SomeString)]
    public static void CreateUnitFailureCodeWithSourceException_SourceExceptionIsNotNull_ExpectActualExceptionIsSame(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception(
            message: "Some error message",
            innerException: new InvalidOperationException("Some inner error text"));

        var actual = Failure.Create(sourceFailureMessage, sourceException);

        AssertEqualFailures(
            (Unit.Value, expectedFailureMessage, sourceException),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
