#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        internal Optional<T> OnPresent(
            Func<T, Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InnerOnPresent(handler, InnerThis);
        }

        internal Optional<T> OnPresent(
            Action<T> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InnerOnPresent(handler.InvokeThenToUnit, InnerThis);
        }

        internal Task<Optional<T>> OnPresentAsync(
            Func<T, Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnPresent(handlerAsync, InnerThisAsync);
        }

        internal Task<Optional<T>> OnPresentAsync(
            Func<T, Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnPresent(handlerAsync, InnerThisAsync);
        }

        internal ValueTask<Optional<T>> OnPresentValueAsync(
            Func<T, ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnPresent(handlerAsync, InnerThisValueAsync);
        }

        internal ValueTask<Optional<T>> OnPresentValueAsync(
            Func<T, ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnPresent(handlerAsync, InnerThisValueAsync);
        }
    }
}
