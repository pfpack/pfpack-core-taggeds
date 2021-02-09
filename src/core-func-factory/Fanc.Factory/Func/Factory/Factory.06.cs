#nullable enable

namespace System
{
    partial class Func
    {
        public static IFunc<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6, TResult>(
            Func<T1, T2, T3, T4, T5, T6, TResult> func)
            =>
            new ImplFunc<T1, T2, T3, T4, T5, T6, TResult>(
                func ?? throw new ArgumentNullException(nameof(func)));
    }
}