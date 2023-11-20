using System;
using Xunit;
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
    [InlineData(SomeFailureCode.First, null, EmptyString)]
    [InlineData(SomeFailureCode.Unknown, EmptyString, EmptyString)]
    [InlineData(SomeFailureCode.Second, SomeString, SomeString)]
    public static void DeconstructWithSourceException_SourceExceptionIsNotNull_ExpectCorrectValue(
        SomeFailureCode sourceFailureCode, string? sourceFailureMessage, string expectedFailureMessage)
    {
        var sourceException = new Exception();

        var source = new Failure<SomeFailureCode>(sourceFailureCode, sourceFailureMessage)
        {
            SourceException = sourceException
        };

        var (actualFailureCode, actualFailureMessage, actualException) = source;

        AssertEqualFailures(
            (sourceFailureCode, expectedFailureMessage, sourceException),
            (actualFailureCode, actualFailureMessage, actualException));
    }
}
