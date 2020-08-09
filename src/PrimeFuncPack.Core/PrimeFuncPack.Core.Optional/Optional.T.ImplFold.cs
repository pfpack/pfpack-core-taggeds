#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult ImplFold<TResult>(in Func<T, TResult> onPresent, in Func<TResult> onAbsent)
        {
            _ = onPresent ?? throw new ArgumentNullException(nameof(onPresent));
            _ = onAbsent ?? throw new ArgumentNullException(nameof(onAbsent));

            return box switch
            {
                not null => onPresent.Invoke(box),
                _ => onAbsent.Invoke()
            };
        }

        private TResult ImplFold<TResult>(in Func<TResult> onPresent, in Func<TResult> onAbsent)
        {
            _ = onPresent ?? throw new ArgumentNullException(nameof(onPresent));
            _ = onAbsent ?? throw new ArgumentNullException(nameof(onAbsent));

            return box switch
            {
                not null => onPresent.Invoke(),
                _ => onAbsent.Invoke()
            };
        }
    }
}
