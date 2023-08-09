using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Failure<TFailureCode>
{
    public override int GetHashCode()
    {
        if (SourceException is not null)
        {
            return HashCode.Combine(
                EqualityContractHashCode(),
                FailureCodeComparer.GetHashCode(FailureCode),
                FailureMessageComparer.GetHashCode(FailureMessage),
                SourceExceptionComparer.GetHashCode(SourceException));
        }

        return HashCode.Combine(
            EqualityContractHashCode(),
            FailureCodeComparer.GetHashCode(FailureCode),
            FailureMessageComparer.GetHashCode(FailureMessage));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(Failure<TFailureCode>));
}
