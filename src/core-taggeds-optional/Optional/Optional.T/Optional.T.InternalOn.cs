#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOn<TResult>(
            Func<T, Unit> onPresent,
            Func<Unit> onElse,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Value, onPresent, onElse);

            return resultSupplier.Invoke();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnPresent<TResult>(
            Func<T, Unit> handler,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Value, handler, Unit.Get);

            return resultSupplier.Invoke();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InternalOnAbsent<TResult>(
            Func<Unit> handler,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Unit.Get, Pipeline.Pipe, handler);
            
            return resultSupplier.Invoke();
        }
    }
}
