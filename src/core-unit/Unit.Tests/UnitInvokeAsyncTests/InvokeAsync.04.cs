using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class UnitInvokeAsyncTests
{
    [Test]
    public void InvokeAsync_04_FuncIsNull_ExpectArgumentNullException()
    {
        Func<StructType, RefType, string, int, Task> funcAsync = null!;

        var arg1 = SomeTextStructType;
        var arg2 = PlusFifteenIdRefType;
        var arg3 = TabString;
        var arg4 = MinusFortyFive;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeAsync(funcAsync, arg1, arg2, arg3, arg4));
        Assert.AreEqual("funcAsync", ex!.ParamName);
    }

    [Test]
    public async Task InvokeAsync_04_ExpectCallFuncOnce()
    {
        var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, string, int, Task>(Task.CompletedTask);

        var arg1 = SomeTextStructType;
        var arg2 = (RefType?)null;
        var arg3 = TabString;
        var arg4 = MinusFortyFive;

        var actual = await Unit.InvokeAsync(mockFuncAsync.Object.Invoke, arg1, arg2, arg3, arg4);

        Assert.AreEqual(Unit.Value, actual);
        mockFuncAsync.Verify(f => f.Invoke(arg1, arg2, arg3, arg4), Times.Once);
    }
}
