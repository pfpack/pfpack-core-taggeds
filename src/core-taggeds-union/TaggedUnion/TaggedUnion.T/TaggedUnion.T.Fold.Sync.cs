namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    public TResult? Fold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond)
        =>
        InnerFold(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)));

    public TResult Fold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        TResult other)
        =>
        InnerFold(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            other);

    public TResult Fold<TResult>(
        Func<TFirst, TResult> mapFirst,
        Func<TSecond, TResult> mapSecond,
        Func<TResult> otherFactory)
        =>
        InnerFold(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));
}
