using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System;

partial struct Absent<T>
{
    public bool Equals(Absent<T> other) => true;

    public override bool Equals([NotNullWhen(true)] object? obj)
        =>
        obj is Absent<T>;

    public override int GetHashCode()
        =>
        HashCode.Combine(
            EqualityComparer<Type>.Default.GetHashCode(typeof(Absent<T>)));
}
