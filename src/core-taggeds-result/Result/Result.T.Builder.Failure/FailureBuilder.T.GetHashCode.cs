using System;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public override int GetHashCode()
        =>
        HashCode.Combine(EqualityContractComparer.GetHashCode(EqualityContract), FailureComparer.GetHashCode(failure));
}
