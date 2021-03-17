#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // TODO: Publish the On methods after the first Core release

        internal Optional<T> OnAbsent(
            Func<Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalHandleOnAbsent(handler, This);
        }

        internal Optional<T> OnAbsent(
            Action handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalHandleOnAbsent(handler.InvokeThenToUnit, This);
        }

        internal Task<Optional<T>> OnAbsentAsync(
            Func<Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalHandleOnAbsent(handlerAsync, ThisAsync);
        }

        internal Task<Optional<T>> OnAbsentAsync(
            Func<Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalHandleOnAbsent(handlerAsync, ThisAsync);
        }

        internal ValueTask<Optional<T>> OnAbsentValueAsync(
            Func<ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalHandleOnAbsent(handlerAsync, ThisValueAsync);
        }

        internal ValueTask<Optional<T>> OnAbsentValueAsync(
            Func<ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalHandleOnAbsent(handlerAsync, ThisValueAsync);
        }
    }
}
