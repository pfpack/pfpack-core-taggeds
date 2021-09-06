#nullable enable

namespace System
{
    // TODO: Rename to ImplFunc in v2.0
    public sealed class ImplFunc2<T1, T2, T3, T4, TResult> : IFunc<T1, T2, T3, T4, TResult>
    {
        private readonly Func<T1, T2, T3, T4, TResult> func;

        internal ImplFunc2(
            Func<T1, T2, T3, T4, TResult> func)
            =>
            this.func = func;

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            =>
            func.Invoke(arg1, arg2, arg3, arg4);
    }
}
