using static System.FormattableString;

namespace System;

partial struct Success<TSuccess>
{
    public override string ToString()
        =>
        Invariant($"Success<{typeof(TSuccess).Name}>:{success}");
}
