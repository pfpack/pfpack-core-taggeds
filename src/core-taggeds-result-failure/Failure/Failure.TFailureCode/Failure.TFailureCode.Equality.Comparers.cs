#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Failure<TFailureCode>
    {
        private static IEqualityComparer<TFailureCode> FailureCodeEqualityComparer
            =>
            EqualityComparer<TFailureCode>.Default;

        private static StringComparer FailureMessageStringComparer
            =>
            StringComparer.Ordinal;
    }
}