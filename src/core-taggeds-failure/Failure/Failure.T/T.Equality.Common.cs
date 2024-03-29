using System.Collections.Generic;

namespace System;

partial struct Failure<TFailureCode>
{
    private static EqualityComparer<TFailureCode> FailureCodeComparer
        =>
        EqualityComparer<TFailureCode>.Default;

    private static StringComparer FailureMessageComparer
        =>
        StringComparer.Ordinal;

    private static ReferenceEqualityComparer SourceExceptionComparer
        =>
        ReferenceEqualityComparer.Instance;
}
