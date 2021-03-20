#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    partial struct SuccessBuilder<TSuccess>
    {
        public override int GetHashCode()
            =>
            success is not null
                ? HashCode.Combine(EqualityContract, SuccessComparer.GetHashCode(success))
                : HashCode.Combine(EqualityContract);
    }
}
