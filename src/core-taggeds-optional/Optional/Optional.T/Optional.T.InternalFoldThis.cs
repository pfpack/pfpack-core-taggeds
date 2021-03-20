#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalFoldThis<TResult>(
            Func<Optional<T>, TResult> map,
            Func<TResult> otherFactory)
            =>
            hasValue
                ? map.Invoke(this)
                : otherFactory.Invoke();
    }
}
