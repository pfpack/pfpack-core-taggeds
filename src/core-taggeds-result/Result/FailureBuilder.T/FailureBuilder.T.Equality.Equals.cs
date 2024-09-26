using System.Collections.Generic;

namespace System;

partial struct FailureBuilder<TFailure>
{
    public bool Equals(FailureBuilder<TFailure> other)
        =>
        EqualityComparer<TFailure>.Default.Equals(failure, other.failure);
}
