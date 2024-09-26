using System.Collections.Generic;

namespace System;

partial struct SuccessBuilder<TSuccess>
{
    public bool Equals(SuccessBuilder<TSuccess> other)
        =>
        EqualityComparer<TSuccess>.Default.Equals(success, other.success);
}
