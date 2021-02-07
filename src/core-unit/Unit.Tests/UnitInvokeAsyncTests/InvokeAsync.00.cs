#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitInvokeAsyncTests
    {
        [Test]
        public void InvokeAsync_00_FuncIsNull_ExpectArgumentNullException()
        {
            Func<Task> funcAsync = null!;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeAsync(funcAsync));

            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        public async Task InvokeAsync_00_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc(Task.CompletedTask);
            var actual = await Unit.InvokeAsync(mockFuncAsync.Object.Invoke);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(), Times.Once);
        }
    }
}
