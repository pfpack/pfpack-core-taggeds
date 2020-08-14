#nullable enable

using System.Collections.Generic;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        // TODO: Implement

        public static bool Equals(in TaggedUnion<TFirst, TSecond> taggedUnionA, in TaggedUnion<TFirst, TSecond> taggedUnionB)
            =>
            throw new NotImplementedException();

        private static IEqualityComparer<TFirst> FirstEqualityComparer => EqualityComparer<TFirst>.Default;

        private static IEqualityComparer<TSecond> SecondEqualityComparer => EqualityComparer<TSecond>.Default;

        private static Type EqualityContract => typeof(TaggedUnion<TFirst, TSecond>);
    }
}
