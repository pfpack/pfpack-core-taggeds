using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

internal static class AssertHelper
{
    public static void AssertEqualFailures<TFailureCode>(
        (TFailureCode FailureCode, string FailureMessage, Exception? SourceException) expected,
        (TFailureCode FailureCode, string FailureMessage, Exception? SourceException) actual)
        where TFailureCode : struct
    {
        Assert.StrictEqual(expected.FailureCode, actual.FailureCode);
        Assert.Equal(expected.FailureMessage, actual.FailureMessage);
        Assert.Equal(expected.SourceException, actual.SourceException);
    }
}
