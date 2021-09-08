#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        internal Optional<T> OnAbsent(
            Func<Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InnerOnAbsent(handler, InnerThis);
        }

        internal Optional<T> OnAbsent(
            Action handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InnerOnAbsent(handler.InvokeThenToUnit, InnerThis);
        }

        internal Task<Optional<T>> OnAbsentAsync(
            Func<Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisAsync);
        }

        internal Task<Optional<T>> OnAbsentAsync(
            Func<Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisAsync);
        }

        internal ValueTask<Optional<T>> OnAbsentValueAsync(
            Func<ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisValueAsync);
        }

        internal ValueTask<Optional<T>> OnAbsentValueAsync(
            Func<ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisValueAsync);
        }
    }
}
