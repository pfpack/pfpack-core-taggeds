#nullable enable

using System.Collections.Generic;

namespace System;

partial struct Failure<TFailureCode>
{
    private static Type EqualityContract
        =>
        typeof(Failure<TFailureCode>);

    private static IEqualityComparer<TFailureCode> FailureCodeComparer
        =>
        EqualityComparer<TFailureCode>.Default;

    private static StringComparer FailureMessageComparer
        =>
        StringComparer.Ordinal;
}
