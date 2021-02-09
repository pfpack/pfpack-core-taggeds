#nullable enable

namespace System
{
    public interface IFunc<in T, out TResult>
    {
        TResult Invoke(T arg);
    }
}