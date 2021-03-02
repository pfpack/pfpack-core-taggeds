#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult InternalOn<TResult>(
            Func<T, Unit> onPresent,
            Func<Unit> onElse,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Value, onPresent, onElse);
            return resultSupplier.Invoke();
        }

        private TResult InternalOnPresent<TResult>(
            Func<T, Unit> handler,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Value, handler, Unit.Get);
            return resultSupplier.Invoke();
        }

        private TResult InternalOnAbsent<TResult>(
            Func<Unit> handler,
            Func<TResult> resultSupplier)
        {
            _ = InternalHandle(Unit.Get, Pipeline.Pipe, handler);
            return resultSupplier.Invoke();
        }
    }
}
