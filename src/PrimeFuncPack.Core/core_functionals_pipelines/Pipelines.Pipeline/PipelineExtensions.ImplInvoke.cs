#nullable enable

namespace System
{
    partial class PipelineExtensions
    {
        private static T ImplInvoke<T>(this T value, in Func<T, Unit> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));

            _ = func.Invoke(value);

            return value;
        }

        private static TResult ImplInvoke<T, TResult>(this T value, in Func<T, TResult> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));

            return func.Invoke(value);
        }
    }
}
