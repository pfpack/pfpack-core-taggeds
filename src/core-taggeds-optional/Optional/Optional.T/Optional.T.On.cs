#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        // TODO: Publish the On methods after the first Core release

        internal Optional<T> On(
            Func<T, Unit> onPresent,
            Func<Unit> onElse)
        {
            _ = onPresent ?? throw new ArgumentNullException(nameof(onPresent));
            _ = onElse ?? throw new ArgumentNullException(nameof(onElse));

            return InternalOn(onPresent, onElse, This);
        }

        internal Optional<T> On(
            Action<T> onPresent,
            Action onElse)
        {
            _ = onPresent ?? throw new ArgumentNullException(nameof(onPresent));
            _ = onElse ?? throw new ArgumentNullException(nameof(onElse));

            return InternalOn(onPresent.InvokeThenToUnit, onElse.InvokeThenToUnit, This);
        }

        internal Task<Optional<T>> OnAsync(
            Func<T, Task<Unit>> onPresentAsync,
            Func<Task<Unit>> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InternalOn(onPresentAsync, onElseAsync, ThisAsync);
        }

        internal Task<Optional<T>> OnAsync(
            Func<T, Task> onPresentAsync,
            Func<Task> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InternalOn(onPresentAsync, onElseAsync, ThisAsync);
        }

        internal ValueTask<Optional<T>> OnValueAsync(
            Func<T, ValueTask<Unit>> onPresentAsync,
            Func<ValueTask<Unit>> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InternalOn(onPresentAsync, onElseAsync, ThisValueAsync);
        }

        internal ValueTask<Optional<T>> OnValueAsync(
            Func<T, ValueTask> onPresentAsync,
            Func<ValueTask> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InternalOn(onPresentAsync, onElseAsync, ThisValueAsync);
        }
    }
}
