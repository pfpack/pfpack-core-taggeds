using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Tests;

partial class UnitExtensionsInvoketValueAsyncTests
{
    [Test]
    public void InvokeThenToUnitValueAsync_00_FuncIsNull_ExpectArgumentNullException()
    {
        Func<ValueTask> funcAsync = null!;
        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitValueAsync().AsTask());

        Assert.AreEqual("funcAsync", ex!.ParamName);
    }

    [Test]
    public async Task InvokeThenToUnitValueAsync_00_ExpectCallFuncOnce()
    {
        var mockFuncAsync = MockFuncFactory.CreateMockFunc<ValueTask>(default);
        var funcAsync = new Func<ValueTask>(mockFuncAsync.Object.Invoke);

        var actual = await funcAsync.InvokeThenToUnitValueAsync();

        Assert.AreEqual(Unit.Value, actual);
        mockFuncAsync.Verify(f => f.Invoke(), Times.Once);
    }
}
