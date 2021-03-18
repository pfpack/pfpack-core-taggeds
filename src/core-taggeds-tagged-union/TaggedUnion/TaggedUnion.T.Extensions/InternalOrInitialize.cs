#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class TaggedUnionExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TResult InternalOrInitialize<TFirst, TSecond, TResult>(
            this TaggedUnion<TFirst, TSecond> union,
            Func<TaggedUnion<TFirst, TSecond>, TResult> map,
            Func<TResult> otherFactory)
            =>
            union.IsInitialized
                ? map.Invoke(union)
                : otherFactory.Invoke();
    }
}
