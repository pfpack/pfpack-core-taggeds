#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial class PipelineExtensions
    {
        public static TResult InvokePipe<T, TResult>(this T value, Func<T, TResult> func)
            =>
            value.ImplInvoke(func);

        public static Task<TResult> InvokePipeAsync<T, TResult>(this T value, Func<T, Task<TResult>> func)
            =>
            value.ImplInvoke(func);

        public static ValueTask<TResult> InvokePipeAsync<T, TResult>(this T value, Func<T, ValueTask<TResult>> func)
            =>
            value.ImplInvoke(func);
    }
}
