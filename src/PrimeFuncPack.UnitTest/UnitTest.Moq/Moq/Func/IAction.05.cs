#nullable enable

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    }
}
