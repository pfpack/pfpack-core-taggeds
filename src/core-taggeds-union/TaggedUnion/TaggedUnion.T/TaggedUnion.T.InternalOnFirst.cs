#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnFirst<THandlerOut, TResult>(
            Func<TFirst, THandlerOut> handler,
            Func<TResult> resultSupplier)
            =>
            InternalOn(
                Tag.First, First, handler, resultSupplier);
    }
}
