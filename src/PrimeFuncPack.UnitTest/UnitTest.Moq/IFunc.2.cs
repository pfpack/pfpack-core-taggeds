#nullable enable

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IFunc<in TFirst, in TSecond, out TResult>
    {
        TResult Invoke(TFirst first, TSecond second);
    }
}
