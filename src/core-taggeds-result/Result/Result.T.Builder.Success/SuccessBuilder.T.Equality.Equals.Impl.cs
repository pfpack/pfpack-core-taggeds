#nullable enable

namespace PrimeFuncPack.Core
{
    partial struct SuccessBuilder<TSuccess>
    {
        public bool Equals(SuccessBuilder<TSuccess> other)
            =>
            SuccessComparer.Equals(success, other.success);
    }
}
