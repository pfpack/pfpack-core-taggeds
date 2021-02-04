#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Tests
{
    partial class InvokeThenToUnitAsyncFuncExtensionsTests
    {
        [Test]
        public void InvokeThenToUnitAsync_00_FuncIsNull_ExpectArgumentNullException()
        {
            Func<Task> funcAsync = null!;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitAsync());

            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        public async Task InvokeThenToUnitAsync_00_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc(Task.CompletedTask);
            var funcAsync = new Func<Task>(mockFuncAsync.Object.Invoke);

            var actual = await funcAsync.InvokeThenToUnitAsync();

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(), Times.Once);
        }
    }
}
