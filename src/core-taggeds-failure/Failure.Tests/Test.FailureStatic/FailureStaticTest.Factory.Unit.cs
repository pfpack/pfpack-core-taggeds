using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Theory]
    [InlineData(null, EmptyString)]
    [InlineData(EmptyString, EmptyString)]
    [InlineData(SomeString, SomeString)]
    public static void CreateUnitFailureCode_ExpectActualValues(
        string? sourceFailureMessage, string expectedFailureMessage)
    {
        var actual = Failure.Create(sourceFailureMessage);

        AssertEqualFailures(
            (Unit.Value, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
