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
    public void InvokeAsync_01_FuncIsNull_ExpectArgumentNullException()
    {
        Func<StructType, Task> funcAsync = null!;
        var arg = SomeTextStructType;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeAsync(funcAsync, arg));

        Assert.AreEqual("funcAsync", ex!.ParamName);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task InvokeAsync_01_ExpectCallFuncOnce(
        bool isArgNull)
    {
        var mockFuncAsync = MockFuncFactory.CreateMockFunc<RefType?, Task>(Task.CompletedTask);

        var arg = isArgNull ? null : MinusFifteenIdRefType;
        var actual = await Unit.InvokeAsync(mockFuncAsync.Object.Invoke, arg);

        Assert.AreEqual(Unit.Value, actual);
        mockFuncAsync.Verify(f => f.Invoke(arg), Times.Once);
    }
}
