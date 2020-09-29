#nullable enable

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IAction<in T>
    {
        void Invoke(T arg);
    }
}
