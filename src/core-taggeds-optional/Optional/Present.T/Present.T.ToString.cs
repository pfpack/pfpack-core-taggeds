using static System.FormattableString;

namespace System;

partial struct Present<T>
{
    public override string ToString()
        =>
        Invariant($"Present<{typeof(T).Name}>:{value}");
}
