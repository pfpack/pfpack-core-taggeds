#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // TODO: Publish the On methods after the first Core release

        internal Optional<T> OnPresent(
            Func<T, Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOnPresent(handler, This);
        }

        internal Optional<T> OnPresent(
            Action<T> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOnPresent(handler.InvokeThenToUnit, This);
        }

        internal Task<Optional<T>> OnPresentAsync(
            Func<T, Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisAsync);
        }

        internal Task<Optional<T>> OnPresentAsync(
            Func<T, Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisAsync);
        }

        internal ValueTask<Optional<T>> OnPresentValueAsync(
            Func<T, ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisValueAsync);
        }

        internal ValueTask<Optional<T>> OnPresentValueAsync(
            Func<T, ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisValueAsync);
        }
    }
}
