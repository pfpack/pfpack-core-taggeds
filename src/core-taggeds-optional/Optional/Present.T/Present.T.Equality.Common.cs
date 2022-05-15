using System.Collections.Generic;

namespace System;

partial struct Present<T>
{
    private static Type EqualityContract
        =>
        typeof(Present<T>);

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static EqualityComparer<T> EqualityComparer
        =>
        EqualityComparer<T>.Default;
}
