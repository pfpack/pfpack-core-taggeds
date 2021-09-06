#nullable enable

namespace System
{
    partial class Func
    {
        public static IFunc<T1, T2, T3, T4, TResult> From<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            =>
            new ImplFunc2<T1, T2, T3, T4, TResult>(
                func ?? throw new ArgumentNullException(nameof(func)));
    }
}
