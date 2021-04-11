#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnTag<TValue, THandlerOut, TResult>(
            Tag expectedTag,
            Func<TValue> valueSupplier,
            Func<TValue, THandlerOut> handler,
            Func<TResult> resultSupplier)
        {
            if (tag == expectedTag)
            {
                _ = handler.Invoke(valueSupplier.Invoke());
            }

            return resultSupplier.Invoke();
        }
    }
}
