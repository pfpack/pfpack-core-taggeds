using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    partial class EqualityComparer
    {
        public bool Equals(TaggedUnion<TFirst, TSecond> x, TaggedUnion<TFirst, TSecond> y)
        {
            if (x.tag != y.tag)
            {
                return false;
            }

            if (x.tag is Tag.First)
            {
                return firstComparer.Equals(x.first, y.first);
            }

            if (x.tag is Tag.Second)
            {
                return secondComparer.Equals(x.second, y.second);
            }

            return true;
        }

        public int GetHashCode(TaggedUnion<TFirst, TSecond> obj)
        {
            if (obj.tag is Tag.First)
            {
                return PresentHashCode(Tag.First, obj.first, firstComparer);
            }

            if (obj.tag is Tag.Second)
            {
                return PresentHashCode(Tag.Second, obj.second, secondComparer);
            }

            return NoneHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int PresentHashCode<TValue>(Tag tag, TValue value, IEqualityComparer<TValue> comparer)
            =>
            value is not null
            ? HashCode.Combine(tag, comparer.GetHashCode(value))
            : HashCode.Combine(tag);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int NoneHashCode()
            =>
            HashCode.Combine(Tag.None);
    }
}
