using System.Collections.Generic;

namespace System;

partial struct Nonsuccess<TFailure>
{
    public bool Equals(Nonsuccess<TFailure> other)
        =>
        EqualityComparer<TFailure>.Default.Equals(failure, other.failure);
}
