#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct Optional<T>
    {
        private static IEqualityComparer<T> ValueEquality => EqualityComparer<T>.Default;
    }
}
