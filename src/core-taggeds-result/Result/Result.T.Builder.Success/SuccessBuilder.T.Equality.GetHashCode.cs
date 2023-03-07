using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    public override int GetHashCode()
        =>
        success is not null
            ? HashCode.Combine(EqualityContractHashCode(), EqualityComparer<TSuccess>.Default.GetHashCode(success))
            : HashCode.Combine(EqualityContractHashCode());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int EqualityContractHashCode()
        =>
        EqualityComparer<Type>.Default.GetHashCode(typeof(SuccessBuilder<TSuccess>));
}
