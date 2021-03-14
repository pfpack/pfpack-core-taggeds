#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Failure<TFailureCode>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string? OrNullIfEmpty(string? value)
            =>
            string.IsNullOrEmpty(value)
                ? null
                : value;
    }
}