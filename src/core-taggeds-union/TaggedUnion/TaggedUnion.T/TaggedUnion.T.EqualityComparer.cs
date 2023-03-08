using System.Collections.Generic;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the class
    internal sealed partial class EqualityComparer : IEqualityComparer<TaggedUnion<TFirst, TSecond>>
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

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
