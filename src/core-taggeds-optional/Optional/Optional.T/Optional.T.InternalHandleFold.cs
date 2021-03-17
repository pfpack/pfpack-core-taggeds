#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalHandleFold<TResult>(
            Func<T, TResult> map,
            Func<TResult> otherFactory)
            =>
            hasValue
                ? map.Invoke(value)
                : otherFactory.Invoke();
    }
}
