using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Failure<TFailureCode>
{
    public override int GetHashCode() => HashCode.Combine(
        EqualityContractHashCode(),
        FailureCodeComparer.GetHashCode(FailureCode),
        FailureMessageComparer.GetHashCode(FailureMessage),
        SourceException is not null ? SourceExceptionComparer.GetHashCode(SourceException) : default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(Failure<TFailureCode>));
}
