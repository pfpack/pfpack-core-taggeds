#nullable enable

namespace System
{
    // TODO: Delete the class in v2.0
    [Obsolete(ImplFuncObsolete.Message, error: true)]
    public sealed class ImplFunc<T1, T2, T3, T4, TResult> : IFunc<T1, T2, T3, T4, TResult>
    {
        private readonly Func<T1, T2, T3, T4, TResult> func;

        public ImplFunc(
            Func<T1, T2, T3, T4, TResult> func)
            =>
            this.func = func;

        public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            =>
            func.Invoke(arg1, arg2, arg3, arg4);
    }
}