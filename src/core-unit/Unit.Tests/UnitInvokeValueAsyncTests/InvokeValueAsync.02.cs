#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitInvokeValueAsyncTests
    {
        [Test]
        public void InvokeValueAsync_02_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, RefType, ValueTask> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeValueAsync(funcAsync, arg1, arg2).AsTask());
            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        public async Task InvokeValueAsync_02_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, ValueTask>(default);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;

            var actual = await Unit.InvokeValueAsync(mockFuncAsync.Object.Invoke, arg1, arg2);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(arg1, arg2), Times.Once);
        }
    }
}
