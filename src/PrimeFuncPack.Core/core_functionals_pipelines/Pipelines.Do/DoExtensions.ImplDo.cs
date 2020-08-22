#nullable enable

namespace System
{
    partial class DoExtensions
    {
        private static T ImplDo<T>(this T value, in Func<T, Unit> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));

            _ = func.Invoke(value);

            return value;
        }

        private static TResult ImplDo<T, TResult>(this T value, in Func<T, TResult> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));

            return func.Invoke(value);
        }
    }
}
