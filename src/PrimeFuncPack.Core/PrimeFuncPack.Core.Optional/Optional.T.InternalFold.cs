#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        private TOuterResult InternalFold<TResult, TOuterResult>(in Func<T, TOuterResult> onPresent, in Func<TOuterResult> onAbsent)
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

        private TOuterResult InternalFold<TResult, TOuterResult>(in Func<TOuterResult> onPresent, in Func<TOuterResult> onAbsent)
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
