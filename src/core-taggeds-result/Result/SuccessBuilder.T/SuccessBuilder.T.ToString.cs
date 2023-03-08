using static System.FormattableString;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    public override string ToString()
        =>
        Invariant($"SuccessBuilder<{typeof(TSuccess).Name}>:{success}");
}
