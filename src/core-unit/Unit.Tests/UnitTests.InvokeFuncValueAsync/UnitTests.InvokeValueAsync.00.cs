#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeValueAsync_00_FuncIsNull_ExpectArgumentNullException()
        {
            Func<ValueTask> funcAsync = null!;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeValueAsync(funcAsync).AsTask());

            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        public async Task InvokeValueAsync_00_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<ValueTask>(default);
            var actual = await Unit.InvokeValueAsync(mockFuncAsync.Object.Invoke);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(), Times.Once);
        }
    }
}
