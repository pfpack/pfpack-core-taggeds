#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalHandleOnAbsent<THandlerResult, TResult>(
            Func<THandlerResult> handler,
            Func<TResult> resultSupplier)
        {
            if (hasValue is false)
            {
                _ = handler.Invoke();
            }

            return resultSupplier.Invoke();
        }
    }
}
