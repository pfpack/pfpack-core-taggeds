#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class PipelineExtensions
    {
        public static TResult PipeSelf<T, TResult>(this T value, Func<T, TResult> pipe)
            =>
            (pipe ?? throw new ArgumentNullException(nameof(pipe)))
            .Invoke(value);
    }
}
