using System.Collections.Generic;

namespace PrimeFuncPack.Core;

partial struct FailureBuilder<TFailure>
{
    public bool Equals(FailureBuilder<TFailure> other)
        =>
        EqualityComparer<TFailure>.Default.Equals(failure, other.failure);
}
