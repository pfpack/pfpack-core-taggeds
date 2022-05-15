using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    private static Type EqualityContract
        =>
        typeof(SuccessBuilder<TSuccess>);

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static EqualityComparer<TSuccess> SuccessComparer 
        =>
        EqualityComparer<TSuccess>.Default;
}
