#nullable enable

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IFunc<in TFirst, in TSecond, in TThird, out TResult>
    {
        TResult Invoke(TFirst first, TSecond second, TThird third);
    }
}
