using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    private static Type EqualityContract
        =>
        typeof(Optional<T>);

    private static EqualityComparer<Type> EqualityContractComparer
        =>
        EqualityComparer<Type>.Default;

    private static EqualityComparer<T> ValueEqualityComparer
        =>
        EqualityComparer<T>.Default;
}
