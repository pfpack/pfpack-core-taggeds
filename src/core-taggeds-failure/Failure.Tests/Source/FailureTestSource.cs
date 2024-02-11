using System;

namespace PrimeFuncPack.Core.Tests;

internal static partial class FailureTestSource
{
    private sealed class SomeException : Exception
    {
        internal static SomeException Instance { get; } = new();
    }
}