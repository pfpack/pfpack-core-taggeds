using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    // TODO: Remove the methods in v3.0

    private const string ObsoleteMessage_IReadOnly
        =
        "This method is obsolete. Call the IEnumerable-based extension method instead.";

    // ElementAtOrAbsent

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        int index)
        =>
        InnerElementAtOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> ElementAtOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        long index)
        =>
        InnerElementAtOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            index);

    // FirstOrAbsent

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> FirstOrAbsent<TSource>(
        IReadOnlyList<TSource> source)
        =>
        InnerFirstOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)));

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> FirstOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerFirstOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));

    // LastOrAbsent

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> LastOrAbsent<TSource>(
        IReadOnlyList<TSource> source)
        =>
        InnerLastOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)));

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> LastOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerLastOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));

    // SingleOrAbsent

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> SingleOrAbsent<TSource>(
        IReadOnlyList<TSource> source)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            InnerCreateMoreThanOneElementException);

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> SingleOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        Func<Exception> moreThanOneElementExceptionFactory)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory)));

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> SingleOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            InnerCreateMoreThanOneMatchException);

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TSource> SingleOrAbsent<TSource>(
        IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate,
        Func<Exception> moreThanOneMatchExceptionFactory)
        =>
        InnerSingleOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)),
            moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory)));

    // GetValueOrAbsent

    [Obsolete(ObsoleteMessage_IReadOnly, error: true)]
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
        =>
        InnerGetValueOrAbsent(
            dictionary ?? throw new ArgumentNullException(nameof(dictionary)),
            key);
}
