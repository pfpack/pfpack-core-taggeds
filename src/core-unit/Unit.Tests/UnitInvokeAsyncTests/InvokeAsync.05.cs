#nullable enable

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
    public void InvokeAsync_05_FuncIsNull_ExpectArgumentNullException()
    {
        Func<StructType, RefType, string, int, object, Task> funcAsync = null!;

        var arg1 = SomeTextStructType;
        var arg2 = PlusFifteenIdRefType;
        var arg3 = TabString;
        var arg4 = MinusFortyFive;
        var arg5 = new { Value = PlusTwoHundredPointFive };

        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeAsync(funcAsync, arg1, arg2, arg3, arg4, arg5));
        Assert.AreEqual("funcAsync", ex!.ParamName);
    }

    [Test]
    public async Task InvokeAsync_05_ExpectCallFuncOnce()
    {
        var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, string, int, object?, Task>(Task.CompletedTask);

        var arg1 = SomeTextStructType;
        var arg2 = (RefType?)null;
        var arg3 = TabString;
        var arg4 = MinusFortyFive;
        var arg5 = new { Value = PlusTwoHundredPointFive };

        var actual = await Unit.InvokeAsync(mockFuncAsync.Object.Invoke, arg1, arg2, arg3, arg4, arg5);

        Assert.AreEqual(Unit.Value, actual);
        mockFuncAsync.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5), Times.Once);
    }
}
