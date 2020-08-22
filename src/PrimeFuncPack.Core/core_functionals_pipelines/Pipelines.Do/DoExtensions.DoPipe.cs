#nullable enable

namespace System
{
    partial class DoExtensions
    {
        public static TResult DoPipe<T, TResult>(this T value, in Func<T, TResult> func)
            =>
            value.ImplDo(func);
    }
}
