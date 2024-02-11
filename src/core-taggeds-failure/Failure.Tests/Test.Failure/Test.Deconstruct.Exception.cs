using System;
using PrimeFuncPack.UnitTest;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [InlineData(int.MinValue, null, EmptyString)]
    [InlineData(Zero, EmptyString, EmptyString)]
    [InlineData(PlusFifteen, SomeString, SomeString)]
    public static void DeconstructWithSourceException_SourceExceptionIsNull_ExpectCorrectValue(
        int sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var source = new Failure<int>(sourceFailureCode, sourceFailureMessage);

        var (actualFailureCode, actualFailureMessage, actualException) = source;

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, null),
            (actualFailureCode, actualFailureMessage, actualException));
    }

    [Theory]
    [InlineData(EnumType.One, null, EmptyString)]
    [InlineData(EnumType.Zero, EmptyString, EmptyString)]
    [InlineData(EnumType.Two, SomeString, SomeString)]
    public static void DeconstructWithSourceException_SourceExceptionIsNotNull_ExpectCorrectValue(
        EnumType sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception();

        var source = new Failure<EnumType>(sourceFailureCode, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var (actualFailureCode, actualFailureMessage, actualException) = source;

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, sourceException),
            (actualFailureCode, actualFailureMessage, actualException));
    }
}
