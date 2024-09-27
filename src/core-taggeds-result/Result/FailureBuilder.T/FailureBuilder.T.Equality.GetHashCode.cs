using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct FailureBuilder<TFailure>
{
    public override int GetHashCode()
        =>
        HashCode.Combine(
            EqualityContractHashCode(), EqualityComparer<TFailure>.Default.GetHashCode(failure));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(FailureBuilder<TFailure>));
}
