#nullable enable

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IFunc<in TSource, out TResult>
    {
        TResult Invoke(TSource source);
    }
}
