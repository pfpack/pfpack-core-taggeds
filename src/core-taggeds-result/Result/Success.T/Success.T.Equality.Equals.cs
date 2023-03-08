using System.Collections.Generic;

namespace System;

partial struct Success<TSuccess>
{
    public bool Equals(Success<TSuccess> other)
        =>
        EqualityComparer<TSuccess>.Default.Equals(success, other.success);
}
