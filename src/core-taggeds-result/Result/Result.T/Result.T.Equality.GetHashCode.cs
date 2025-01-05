using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public override int GetHashCode()
    {
        if (isSuccess)
        {
            return success is not null
                ? HashCode.Combine(EqualityContractHashCode(), true, EqualityComparer<TSuccess>.Default.GetHashCode(success))
                : HashCode.Combine(EqualityContractHashCode(), true);
        }

        return HashCode.Combine(EqualityContractHashCode(), false, EqualityComparer<TFailure>.Default.GetHashCode(failure));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(Result<TSuccess, TFailure>));
}
