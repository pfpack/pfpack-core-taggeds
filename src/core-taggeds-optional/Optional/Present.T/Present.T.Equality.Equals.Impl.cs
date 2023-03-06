using System.Collections.Generic;

namespace System;

partial struct Present<T>
{
    public bool Equals(Present<T> other)
        =>
        EqualityComparer<T>.Default.Equals(value, other.value);
}
