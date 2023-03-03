using static System.FormattableString;

namespace System;

partial struct Absent<T>
{
    public override string ToString()
        =>
        Invariant($"Absent<{typeof(T).Name}>:()");
}
