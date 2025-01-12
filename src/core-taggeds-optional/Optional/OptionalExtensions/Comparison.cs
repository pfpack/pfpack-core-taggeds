namespace System;

partial class OptionalExtensions
{
    // TODO: Add the tests and open the method
    internal static int CompareTo<T>(this Optional<T> optional, Optional<T> other)
        where T : IComparable<T>
        =>
        OptionalComparer<T>.Default.Compare(optional, other);
}
