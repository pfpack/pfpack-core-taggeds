#nullable enable

namespace System
{
    partial class Func
    {
        public static IFunc<T1, T2, TResult> From<T1, T2, TResult>(
            Func<T1, T2, TResult> func)
            =>
            new ImplFunc<T1, T2, TResult>(
                func ?? throw new ArgumentNullException(nameof(func)));
    }
}