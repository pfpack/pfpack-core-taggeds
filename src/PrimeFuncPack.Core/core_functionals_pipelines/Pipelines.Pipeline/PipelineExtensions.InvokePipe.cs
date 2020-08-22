#nullable enable

namespace System
{
    partial class PipelineExtensions
    {
        public static TResult InvokePipe<T, TResult>(this T value, Func<T, TResult> func)
            =>
            value.ImplInvoke(func);
    }
}
