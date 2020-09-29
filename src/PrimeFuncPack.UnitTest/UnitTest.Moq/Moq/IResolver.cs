#nullable enable

using System;

namespace PrimeFuncPack.UnitTest.Moq
{
    public interface IResolver<out T>
    {
        T Resolve(IServiceProvider serviceProvider);
    }
}
