#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnSecond<THandlerOut, TResult>(
            Func<TSecond, THandlerOut> handler,
            Func<TResult> resultSupplier)
            =>
            InternalOn(
                Tag.Second, Second, handler, resultSupplier);
    }
}
