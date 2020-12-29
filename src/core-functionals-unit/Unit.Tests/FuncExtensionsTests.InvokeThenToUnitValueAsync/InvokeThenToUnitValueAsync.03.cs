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
        public void InvokeThenToUnitValueAsync_03_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, RefType, string, ValueTask> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitValueAsync(arg1, arg2, arg3).AsTask());
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public async Task InvokeThenToUnitValueAsync_03_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, string, ValueTask>(default);
            var funcAsync = new Func<StructType, RefType?, string, ValueTask>(mockFuncAsync.Object.Invoke);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;

            var actual = await funcAsync.InvokeThenToUnitValueAsync(arg1, arg2, arg3);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(arg1, arg2, arg3), Times.Once);
        }
    }
}
