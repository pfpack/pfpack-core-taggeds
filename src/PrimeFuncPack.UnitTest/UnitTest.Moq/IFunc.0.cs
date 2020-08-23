#nullable enable

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IFunc<out TResult>
    {
        TResult Invoke();
    }
}
