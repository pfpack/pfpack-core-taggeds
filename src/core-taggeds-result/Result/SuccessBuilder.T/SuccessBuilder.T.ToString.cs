using static System.FormattableString;

namespace System;

partial struct SuccessBuilder<TSuccess>
{
    public override string ToString()
        =>
        Invariant($"SuccessBuilder<{typeof(TSuccess).Name}>:{success}");
}
