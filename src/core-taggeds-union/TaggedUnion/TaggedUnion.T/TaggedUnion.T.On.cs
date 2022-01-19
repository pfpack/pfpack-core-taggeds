using System.Threading.Tasks;

namespace System;

partial struct TaggedUnion<TFirst, TSecond>
{
    // TODO: Add the tests and open the methods
    internal TaggedUnion<TFirst, TSecond> On(
        Action<TFirst> onFirst,
        Action<TSecond> onSecond)
        =>
        InnerOn(
            onFirst ?? throw new ArgumentNullException(nameof(onFirst)),
            onSecond ?? throw new ArgumentNullException(nameof(onSecond)));

    internal Task<TaggedUnion<TFirst, TSecond>> OnAsync(
        Func<TFirst, Task> onFirstAsync,
        Func<TSecond, Task> onSecondAsync)
        =>
        InnerOnAsync(
            onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync)),
            onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync)));

    internal ValueTask<TaggedUnion<TFirst, TSecond>> OnValueAsync(
        Func<TFirst, ValueTask> onFirstAsync,
        Func<TSecond, ValueTask> onSecondAsync)
        =>
        InnerOnValueAsync(
            onFirstAsync ?? throw new ArgumentNullException(nameof(onFirstAsync)),
            onSecondAsync ?? throw new ArgumentNullException(nameof(onSecondAsync)));
}
