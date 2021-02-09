#nullable enable

namespace System
{
    partial class Func
    {
        public static IFunc<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(
            Func<T1, T2, T3, TResult> func)
            =>
            throw new NotImplementedException();
    }
}