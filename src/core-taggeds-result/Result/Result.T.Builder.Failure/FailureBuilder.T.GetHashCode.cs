#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    partial struct FailureBuilder<TFailure>
    {
        public override int GetHashCode()
            =>
            HashCode.Combine(EqualityContract, FailureComparer.GetHashCode(failure));
    }
}
