#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TResult ImplFold<TResult>(in Func<T, TResult> onPresent, in Func<TResult> onAbsent)
        {
            if (onPresent is null)
            {
                throw new ArgumentNullException(nameof(onPresent));
            }

            if (onAbsent is null)
            {
                throw new ArgumentNullException(nameof(onAbsent));
            }

            return box switch
            {
                null => onAbsent.Invoke(),
                var present => onPresent.Invoke(present)
            };
        }

        private TResult ImplFold<TResult>(in Func<TResult> onPresent, in Func<TResult> onAbsent)
        {
            if (onPresent is null)
            {
                throw new ArgumentNullException(nameof(onPresent));
            }

            if (onAbsent is null)
            {
                throw new ArgumentNullException(nameof(onAbsent));
            }

            return box switch
            {
                null => onAbsent.Invoke(),
                _ => onPresent.Invoke()
            };
        }
    }
}
