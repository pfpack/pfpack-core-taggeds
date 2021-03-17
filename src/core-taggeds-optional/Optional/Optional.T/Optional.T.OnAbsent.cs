#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // TODO: Publish the On methods after the first Core release

        internal Optional<T> OnAbsent<TResult>(
            Func<Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOn(Unit.From, handler, This);
        }

        internal Optional<T> OnAbsent<TResult>(
            Action handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOn(Unit.From, handler.InvokeThenToUnit, This);
        }

        internal Task<Optional<T>> OnAbsentAsync<TResult>(
            Func<Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOn(_ => Task.FromResult<Unit>(default), handlerAsync, ThisAsync);
        }

        internal Task<Optional<T>> OnAbsentAsync<TResult>(
            Func<Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOn(_ => Task.CompletedTask, handlerAsync, ThisAsync);
        }

        internal ValueTask<Optional<T>> OnAbsentValueAsync<TResult>(
            Func<ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOn(_ => default, handlerAsync, ThisValueAsync);
        }

        internal ValueTask<Optional<T>> OnAbsentValueAsync<TResult>(
            Func<ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOn(_ => default, handlerAsync, ThisValueAsync);
        }
    }
}
