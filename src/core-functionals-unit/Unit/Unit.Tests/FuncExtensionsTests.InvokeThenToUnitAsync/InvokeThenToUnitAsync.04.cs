#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Tests
{
    partial class InvokeThenToUnitAsyncFuncExtensionsTests
    {
        [Test]
        public void InvokeThenToUnitAsync_04_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, RefType, string, int, Task> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitAsync(arg1, arg2, arg3, arg4));
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public async Task InvokeThenToUnitAsync_04_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, string, int, Task>(Task.CompletedTask);
            var funcAsync = new Func<StructType, RefType?, string, int, Task>(mockFuncAsync.Object.Invoke);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;

            var actual = await funcAsync.InvokeThenToUnitAsync(arg1, arg2, arg3, arg4);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(arg1, arg2, arg3, arg4), Times.Once);
        }
    }
}
