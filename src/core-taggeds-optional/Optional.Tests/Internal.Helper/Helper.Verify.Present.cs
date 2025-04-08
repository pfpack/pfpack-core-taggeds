using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyPresentInnerState<T>(this Optional<T> actual, T? expectedValue)
    {
        var actualHasValue = actual.GetStructFieldValue<bool>("hasValue");
        Assert.True(actualHasValue);

        var actualValue = actual.GetFieldValue<T?>("value");
        Assert.Equal(expectedValue, actualValue);
    }
}