#nullable enable

namespace System
{
    partial class Func
    {
        public static IFunc<TResult> Create<TResult>(
            Func<TResult> func)
            =>
            new ImplFunc<TResult>(
                func ?? throw new ArgumentNullException(nameof(func)));
    }
}