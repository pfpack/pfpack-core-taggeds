#nullable enable

namespace System
{
    public interface IFunc<out TResult>
    {
        TResult Invoke();
    }
}
