using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    private static Type EqualityContract => typeof(Optional<T>);

    private static IEqualityComparer<T> EqualityComparer => EqualityComparer<T>.Default;
}
