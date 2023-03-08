using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the class
    internal sealed class EqualityComparer : IEqualityComparer<TaggedUnion<TFirst, TSecond>>
    {
        private readonly IEqualityComparer<TFirst> firstComparer;

        private readonly IEqualityComparer<TSecond> secondComparer;

        private EqualityComparer(
            IEqualityComparer<TFirst> firstComparer,
            IEqualityComparer<TSecond> secondComparer)
        {
            this.firstComparer = firstComparer;
            this.secondComparer = secondComparer;
        }

        public static EqualityComparer Create(
            IEqualityComparer<TFirst>? firstComparer,
            IEqualityComparer<TSecond>? secondComparer)
            =>
            new(
                firstComparer ?? EqualityComparer<TFirst>.Default,
                secondComparer ?? EqualityComparer<TSecond>.Default);

        public static EqualityComparer Create(IEqualityComparer<TFirst>? firstComparer)
            =>
            new(
                firstComparer ?? EqualityComparer<TFirst>.Default,
                EqualityComparer<TSecond>.Default);

        public static EqualityComparer Create(IEqualityComparer<TSecond>? secondComparer)
            =>
            new(
                EqualityComparer<TFirst>.Default,
                secondComparer ?? EqualityComparer<TSecond>.Default);

        public static EqualityComparer Create()
            =>
            new(
                EqualityComparer<TFirst>.Default,
                EqualityComparer<TSecond>.Default);

        public static EqualityComparer Default
            =>
            InnerDefault.Value;

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
                return FirstHashCode(obj.first);
            }

            if (obj.tag is Tag.Second)
            {
                return SecondHashCode(obj.second);
            }

            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FirstHashCode(TFirst first)
            =>
            first is not null
                ? HashCode.Combine(Tag.First, firstComparer.GetHashCode(first))
                : HashCode.Combine(Tag.First);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int SecondHashCode(TSecond second)
            =>
            second is not null
                ? HashCode.Combine(Tag.Second, secondComparer.GetHashCode(second))
                : HashCode.Combine(Tag.Second);

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
