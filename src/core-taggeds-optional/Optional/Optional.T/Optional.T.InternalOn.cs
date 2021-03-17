#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOn<TPresentResult, TElseResult, TResult>(
            Func<T, TPresentResult> onPresent,
            Func<TElseResult> onElse,
            Func<TResult> resultSupplier)
        {
            if (hasValue)
            {
                _ = onPresent.Invoke(value);
            }
            else
            {
                _ = onElse.Invoke();
            }

            return resultSupplier.Invoke();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnPresent<THandlerResult, TResult>(
            Func<T, THandlerResult> handler,
            Func<TResult> resultSupplier)
        {
            if (hasValue)
            {
                _ = handler.Invoke(value);
            }

            return resultSupplier.Invoke();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnAbsent<THandlerResult, TResult>(
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
