#nullable enable

namespace System
{
    internal sealed class ImplFunc<T, TResult> : IFunc<T, TResult>
    {
        private readonly Func<T, TResult> func;

        public ImplFunc(
            Func<T, TResult> func)
            =>
            this.func = func;

        public TResult Invoke(T arg)
            =>
            func.Invoke(arg);
    }
}