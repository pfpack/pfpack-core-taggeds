using System;

namespace PrimeFuncPack.Core.Tests;

partial class TestHelper
{
    internal static Optional<T> InitializePresentOptional<T>(this T value)
    {
        // Use a boxed default array instance to modify its inner state next
        object optional = default(Optional<T>);

        optional.SetFieldValue("hasValue", true);
        optional.SetFieldValue("value", value);

        return (Optional<T>)optional;
    }
}