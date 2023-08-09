using System;

namespace PrimeFuncPack.Core.Tests;

internal static partial class FailureTestSource
{
    private sealed class SomeException : Exception
    {
        public static readonly SomeException SomeInstance;

        static SomeException()
            =>
            SomeInstance = new();
    }
}