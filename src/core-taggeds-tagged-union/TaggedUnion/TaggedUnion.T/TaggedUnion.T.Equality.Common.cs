#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        private static Type EqualityContract => typeof(TaggedUnion<TFirst, TSecond>);

        private static IEqualityComparer<TFirst> FirstComparer => EqualityComparer<TFirst>.Default;

        private static IEqualityComparer<TSecond> SecondComparer => EqualityComparer<TSecond>.Default;
    }
}
