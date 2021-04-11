#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion<TFirst, TSecond> OnSecond(
            Func<TSecond, Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOnSecond(handler, This);
        }

        public TaggedUnion<TFirst, TSecond> OnSecond(
            Action<TSecond> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOnSecond(handler.InvokeThenToUnit, This);
        }

        public Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
            Func<TSecond, Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnSecond(handlerAsync, ThisAsync);
        }

        public Task<TaggedUnion<TFirst, TSecond>> OnSecondAsync(
            Func<TSecond, Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnSecond(handlerAsync, ThisAsync);
        }

        public ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
            Func<TSecond, ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnSecond(handlerAsync, ThisValueAsync);
        }

        public ValueTask<TaggedUnion<TFirst, TSecond>> OnSecondValueAsync(
            Func<TSecond, ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnSecond(handlerAsync, ThisValueAsync);
        }
    }
}
