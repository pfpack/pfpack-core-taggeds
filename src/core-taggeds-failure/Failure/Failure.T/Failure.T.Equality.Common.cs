using System.Collections.Generic;

namespace System;

partial struct Failure<TFailureCode>
{
    private static Type EqualityContract
        =>
        typeof(Failure<TFailureCode>);

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static EqualityComparer<TFailureCode> FailureCodeComparer
        =>
        EqualityComparer<TFailureCode>.Default;

    private static StringComparer FailureMessageComparer
        =>
        StringComparer.Ordinal;
}
