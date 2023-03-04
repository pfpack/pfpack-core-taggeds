using System.Collections.Generic;

namespace System;

// TODO: Add the tests and open the class
internal sealed class OptionalComparer<T> : IComparer<Optional<T>> where T : IComparable<T>
{
    private readonly Optional<T>.Comparer comparer;

    private OptionalComparer(Optional<T>.Comparer comparer)
        =>
        this.comparer = comparer;

    public static OptionalComparer<T> Create(IComparer<T>? comparer)
        =>
        new(new(comparer ?? Comparer<T>.Default));

    public static OptionalComparer<T> Create()
        =>
        new(new(Comparer<T>.Default));

    public static OptionalComparer<T> Default => InnerDefault.Value;

    public int Compare(Optional<T> x, Optional<T> y)
        =>
        comparer.Compare(x, y);

    private static class InnerDefault
    {
        internal static readonly OptionalComparer<T> Value = Create();
    }
}
