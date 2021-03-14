#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalFold<TResult>(Func<T, TResult> map, Func<TResult> otherFactory)
            =>
            InternalHandle(Value, map, otherFactory);
    }
}
