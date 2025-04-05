using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static void VerifyDefaultInnerState<T>(this Optional<T> actual)
    {
        var actualHasValue = actual.GetStructFieldValue<bool>("hasValue");
        Assert.False(actualHasValue);

        var actualValue = actual.GetFieldValue<T?>("value");
        Assert.Equal(default, actualValue);
    }
}