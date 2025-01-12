using System.Collections.Generic;

namespace System;

partial struct Optional<T>
{
    // TODO: Add the tests and open the type
    internal sealed partial class EqualityComparer : IEqualityComparer<Optional<T>>
    {
        private readonly IEqualityComparer<T> comparer;

        private EqualityComparer(IEqualityComparer<T> comparer)
            =>
            this.comparer = comparer;

        public static EqualityComparer Create(IEqualityComparer<T>? comparer)
            =>
            new(comparer ?? EqualityComparer<T>.Default);

        public static EqualityComparer Create()
            =>
            new(EqualityComparer<T>.Default);

        public static EqualityComparer Default
            =>
            InnerDefault.Value;

        private static class InnerDefault
        {
            internal static readonly EqualityComparer Value = Create();
        }
    }
}
