using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InnerOn<TOnPresentOut, TOnElseOut, TResult>(
            Func<T, TOnPresentOut> onPresent,
            Func<TOnElseOut> onElse,
            Func<TResult> resultSupplier)
        {
            if (hasValue)
            {
                _ = onPresent.Invoke(value);
            }
            else
            {
                _ = onElse.Invoke();
            }

            return resultSupplier.Invoke();
        }
    }
}
