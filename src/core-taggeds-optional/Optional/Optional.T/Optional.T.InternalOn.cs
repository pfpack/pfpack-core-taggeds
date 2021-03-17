#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOn<THandlerResult, TResult>(
            Func<T, THandlerResult> onPresent,
            Func<THandlerResult> onElse,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Value, onPresent, onElse);

            return resultSupplier.Invoke();
        }
    }
}
