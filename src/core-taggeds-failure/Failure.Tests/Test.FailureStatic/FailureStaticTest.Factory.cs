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
    public static void Create_ExpectActualValues(
        EnumType sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var actual = Failure.Create(sourceFailureCode, sourceFailureMessage);

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, null),
            (actual.FailureCode, actual.FailureMessage, actual.SourceException));
    }
}
