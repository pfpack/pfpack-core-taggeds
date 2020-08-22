#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using PrimeFuncPack.UnitTest.Tests.TestData;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    public sealed class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockResolver_ThanResolve_ExpectActualResult()
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

        [Fact]
        public void CreateMockFunc_0_ThanInvoke_ExpectActualResult()
        {
            var result = new SomeStruct
            {
                Id = 15
            };

            var actualMock = MockFuncFactory.CreateMockFunc(result);
            var actual = actualMock.Object.Invoke();

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(), Times.Once);
        }

        [Fact]
        public void CreateMockFunc_1_ThanInvoke_ExpectActualResult()
        {
            var result = new SomeStruct
            {
                Id = 15
            };

            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct>(result);

            var source = "Some Text";
            var actual = actualMock.Object.Invoke(source);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(source), Times.Once);
        }

        [Fact]
        public void CreateMockFunc_2_ThanInvoke_ExpectActualResult()
        {
            var result = new SomeType
            {
                Text = "Some Source"
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, SomeType>(result);

            var first = "Some Text";
            var second = new SomeStruct
            {
                Id = 11
            };

            var actual = actualMock.Object.Invoke(first, second);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(first, second), Times.Once);
        }

        [Fact]
        public void CreateMockFunc_3_ThanInvoke_ExpectActualResult()
        {
            var result = new SomeType
            {
                Text = "Some Source"
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, object, SomeType>(result);

            var first = "Some Text";
            var second = new SomeStruct
            {
                Id = 11
            };
            var third = new
            {
                Value = "Some Third"
            };

            var actual = actualMock.Object.Invoke(first, second, third);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(first, second, third), Times.Once);
        }
    }
}
