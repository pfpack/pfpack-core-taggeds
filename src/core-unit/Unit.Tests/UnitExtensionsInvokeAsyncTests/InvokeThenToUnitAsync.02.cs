#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class UnitExtensionsInvokeAsyncTests
{
    [Test]
    public void InvokeThenToUnitAsync_02_FuncIsNull_ExpectArgumentNullException()
    {
        Func<StructType, RefType, Task> funcAsync = null!;

        var arg1 = SomeTextStructType;
        var arg2 = PlusFifteenIdRefType;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitAsync(arg1, arg2));
        Assert.AreEqual("funcAsync", ex!.ParamName);
    }

    [Test]
    public async Task InvokeThenToUnitAsync_02_ExpectCallFuncOnce()
    {
        var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, Task>(Task.CompletedTask);
        var funcAsync = new Func<StructType, RefType?, Task>(mockFuncAsync.Object.Invoke);

        var arg1 = SomeTextStructType;
        var arg2 = (RefType?)null;

        var actual = await funcAsync.InvokeThenToUnitAsync(arg1, arg2);

        Assert.AreEqual(Unit.Value, actual);
        mockFuncAsync.Verify(f => f.Invoke(arg1, arg2), Times.Once);
    }
}
