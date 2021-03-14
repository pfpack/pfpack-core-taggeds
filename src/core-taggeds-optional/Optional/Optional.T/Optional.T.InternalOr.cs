#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOr<TResult>(Func<Optional<T>, TResult> map, Func<TResult> otherFactory)
            =>
            InternalHandle(This, map, otherFactory);
    }
}
