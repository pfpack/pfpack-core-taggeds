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
            InternalOnTag(
                Tag.First, First, handler, resultSupplier);
    }
}
