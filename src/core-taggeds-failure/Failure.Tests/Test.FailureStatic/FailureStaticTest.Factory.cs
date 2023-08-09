using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Theory]
    [InlineData(SomeFailureCode.First, null, EmptyString)]
    [InlineData(SomeFailureCode.Second, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, SomeString, SomeString)]
    public static void Create_ExpectActualValues(
        SomeFailureCode sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var actual = Failure.Create(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
