#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalHandleOnPresent<THandlerOut, TResult>(
            Func<T, THandlerOut> handler,
            Func<TResult> resultSupplier)
        {
            if (hasValue)
            {
                _ = handler.Invoke(value);
            }

            return resultSupplier.Invoke();
        }
    }
}
