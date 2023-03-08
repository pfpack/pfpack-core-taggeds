using System.Collections.Generic;

namespace PrimeFuncPack.Core;

partial struct SuccessBuilder<TSuccess>
{
    public bool Equals(SuccessBuilder<TSuccess> other)
        =>
        EqualityComparer<TSuccess>.Default.Equals(success, other.success);
}
