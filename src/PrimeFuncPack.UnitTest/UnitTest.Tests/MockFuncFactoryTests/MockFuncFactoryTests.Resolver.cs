#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockResolver_ThenResolve_ExpectActualResult()
        {
            var result = new SomeType
            {
                Text = "Some Text"
            };

            var actualMock = MockFuncFactory.CreateMockResolver(result);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualMock.Object.Resolve(serviceProvider);

            Assert.Equal(result, actual);
            actualMock.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }
    }
}
