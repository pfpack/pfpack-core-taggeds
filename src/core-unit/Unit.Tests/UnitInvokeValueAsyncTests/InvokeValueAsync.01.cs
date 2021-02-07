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
        public void InvokeValueAsync_01_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, ValueTask> funcAsync = null!;
            var arg = SomeTextStructType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeValueAsync(funcAsync, arg).AsTask());

            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task InvokeValueAsync_01_ExpectCallFuncOnce(
            bool isArgNull)
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<RefType?, ValueTask>(default);

            var arg = isArgNull ? null : MinusFifteenIdRefType;
            var actual = await Unit.InvokeValueAsync(mockFuncAsync.Object.Invoke, arg);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(arg), Times.Once);
        }
    }
}
