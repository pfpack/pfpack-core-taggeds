using Xunit;

namespace PrimeFuncPack.Core.Tests;

internal static class AssertHelper
{
    public static void AssertEqualFailures<TFailureCode>(
        (TFailureCode FailureCode, string FailureMessage) expected,
        (TFailureCode FailureCode, string FailureMessage) actual)
        where TFailureCode : struct
    {
        Assert.Equal(expected.FailureCode, actual.FailureCode);
        Assert.Equal(expected.FailureMessage, actual.FailureMessage);
    }
}
