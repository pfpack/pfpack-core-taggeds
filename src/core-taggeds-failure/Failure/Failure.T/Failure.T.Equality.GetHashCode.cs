using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Failure<TFailureCode>
{
    public override int GetHashCode()
    {
        HashCode builder = new();

        builder.Add(EqualityContractHashCode());
        builder.Add(FailureCodeComparer.GetHashCode(FailureCode));
        builder.Add(FailureMessageComparer.GetHashCode(FailureMessage));

        if (SourceException is not null)
        {
            builder.Add(SourceExceptionComparer.GetHashCode(SourceException));
        }

        return builder.ToHashCode();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(Failure<TFailureCode>));
}
