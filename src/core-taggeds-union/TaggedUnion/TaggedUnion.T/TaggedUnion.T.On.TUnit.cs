using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> On<TUnit>(
        Func<TFirst, TUnit> onFirst,
        Func<TSecond, TUnit> onSecond)
        =>
        InnerOn(
            onFirst ?? throw new ArgumentNullException(nameof(onFirst)),
            onSecond ?? throw new ArgumentNullException(nameof(onSecond)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnAsync<TUnit>(
        Func<TFirst, Task<TUnit>> onFirstAsync,
        Func<TSecond, Task<TUnit>> onSecondAsync)
        =>
        InnerOnAsync(
            onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync)),
            onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnValueAsync<TUnit>(
        Func<TFirst, ValueTask<TUnit>> onFirstAsync,
        Func<TSecond, ValueTask<TUnit>> onSecondAsync)
        =>
        InnerOnValueAsync(
            onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync)),
            onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync)));
}
