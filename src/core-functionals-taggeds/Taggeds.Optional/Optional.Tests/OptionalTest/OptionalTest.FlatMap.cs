#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void FlatMap_MapIsNull_ExpectArgumentNullException()
        {
            var source = Optional<RefType>.Present(PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FlatMap<StructType>(null!));
            Assert.AreEqual("map", ex.ParamName);
        }

        [Test]
        public void FlatMap_SourceIsAbsent_ExpectNeverCallMap()
        {
            var source = Optional<StructType>.Absent;
            var result = Optional<RefType>.Present(MinusFifteenIdRefType);
            var mockMap = MockFuncFactory.CreateMockFunc<StructType, Optional<RefType>>(result);

            _ = source.FlatMap(mockMap.Object.Invoke);
            mockMap.Verify(p => p.Invoke(It.IsAny<StructType>()), Times.Never);
        }

        [Test]
        public void FlatMap_SourceIsAbsent_ExpectAbsent()
        {
            var source = Optional<RefType>.Absent;
            var result = Optional<RefType>.Present(PlusFifteenIdRefType);
            var mockMap = MockFuncFactory.CreateMockFunc<RefType, Optional<RefType>>(result);

            var actual = source.FlatMap(mockMap.Object.Invoke);
            Assert.True(actual.IsAbsent);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void FlatMap_SourceIsPresent_ExpectCallMapOnce(
            bool isSourceValueNull)
        {
            var sourceValue = isSourceValueNull ? null : MinusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var result = Optional<StructType>.Absent;
            var mockMap = MockFuncFactory.CreateMockFunc<RefType?, Optional<StructType>>(result);

            _ = source.FlatMap(mockMap.Object.Invoke);
            mockMap.Verify(p => p.Invoke(sourceValue), Times.Once);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void FlatMap_SourceIsPresent_ExpectResultValue(
            bool isResultPresent)
        {
            var source = Optional<StructType?>.Present(SomeTextStructType);
            var result = isResultPresent ? Optional<RefType?>.Present(PlusFifteenIdRefType) : Optional<RefType?>.Absent;
            var mockMap = MockFuncFactory.CreateMockFunc<StructType?, Optional<RefType?>>(result);

            var actual = source.FlatMap(mockMap.Object.Invoke);
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void FlatMapAsync_MapAsyncIsNull_ExpectArgumentNullException()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);

            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.FlatMapAsync<int>(null!));
            Assert.AreEqual("mapAsync", ex.ParamName);
        }

        [Test]
        public async Task FlatMapAsync_SourceIsAbsent_ExpectNeverCallMapAsync()
        {
            var source = Optional<RefType>.Absent;
            var result = Optional<StructType>.Present(SomeTextStructType);
            var mockMap = MockFuncFactory.CreateMockFunc<RefType, Task<Optional<StructType>>>(Task.FromResult(result));

            _ = await source.FlatMapAsync(mockMap.Object.Invoke);
            mockMap.Verify(p => p.Invoke(It.IsAny<RefType>()), Times.Never);
        }

        [Test]
        public async Task FlatMapAsync_SourceIsAbsent_ExpectAbsent()
        {
            var source = Optional<StructType?>.Absent;
            var result = Optional<RefType>.Present(PlusFifteenIdRefType);
            var mockMap = MockFuncFactory.CreateMockFunc<StructType?, Task<Optional<RefType>>>(Task.FromResult(result));

            var actual = await source.FlatMapAsync(mockMap.Object.Invoke);
            Assert.True(actual.IsAbsent);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task FlatMapAsync_SourceIsPresent_ExpectCallMapAsyncOnce(
            bool isSourceValueNull)
        {
            var sourceValue = isSourceValueNull ? null : (StructType?)SomeTextStructType;
            var source = Optional<StructType?>.Present(sourceValue);

            var result = Optional<RefType?>.Absent;
            var mockMap = MockFuncFactory.CreateMockFunc<StructType?, Task<Optional<RefType?>>>(Task.FromResult(result));

            _ = await source.FlatMapAsync(mockMap.Object.Invoke);
            mockMap.Verify(p => p.Invoke(sourceValue), Times.Once);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task FlatMapAsync_SourceIsPresent_ExpectResultValue(
            bool isResultPresent)
        {
            var source = Optional<RefType?>.Present(null);
            var result = isResultPresent ? Optional<StructType?>.Present(SomeTextStructType) : Optional<StructType?>.Absent;
            var mockMap = MockFuncFactory.CreateMockFunc<RefType?, Task<Optional<StructType?>>>(Task.FromResult(result));

            var actual = await source.FlatMapAsync(mockMap.Object.Invoke);
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void FlatMapValueAsync_MapAsyncIsNull_ExpectArgumentNullException()
        {
            var source = Optional<RefType?>.Present(PlusFifteenIdRefType);

            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.FlatMapValueAsync<int>(null!));
            Assert.AreEqual("mapAsync", ex.ParamName);
        }

        [Test]
        public async Task FlatMapValueAsync_SourceIsAbsent_ExpectNeverCallMapAsync()
        {
            var source = Optional<StructType?>.Absent;
            var result = Optional<RefType>.Present(MinusFifteenIdRefType);
            var mockMap = MockFuncFactory.CreateMockFunc<StructType?, ValueTask<Optional<RefType>>>(ValueTask.FromResult(result));

            _ = await source.FlatMapValueAsync(mockMap.Object.Invoke);
            mockMap.Verify(p => p.Invoke(It.IsAny<StructType?>()), Times.Never);
        }

        [Test]
        public async Task FlatMapValueAsync_SourceIsAbsent_ExpectAbsent()
        {
            var source = Optional<RefType>.Absent;
            var result = Optional<StructType>.Present(SomeTextStructType);
            var mockMap = MockFuncFactory.CreateMockFunc<RefType, ValueTask<Optional<StructType>>>(ValueTask.FromResult(result));

            var actual = await source.FlatMapValueAsync(mockMap.Object.Invoke);
            Assert.True(actual.IsAbsent);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task FlatMapValueAsync_SourceIsPresent_ExpectCallMapAsyncOnce(
            bool isSourceValueNull)
        {
            var sourceValue = isSourceValueNull ? null : PlusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var result = Optional<StructType>.Absent;
            var mockMap = MockFuncFactory.CreateMockFunc<RefType?, ValueTask<Optional<StructType>>>(ValueTask.FromResult(result));

            _ = await source.FlatMapValueAsync(mockMap.Object.Invoke);
            mockMap.Verify(p => p.Invoke(sourceValue), Times.Once);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task FlatMapValueAsync_SourceIsPresent_ExpectResultValue(
            bool isResultPresent)
        {
            var source = Optional<StructType>.Present(default);
            var result = isResultPresent ? Optional<RefType?>.Present(MinusFifteenIdRefType) : Optional<RefType?>.Absent;
            var mockMap = MockFuncFactory.CreateMockFunc<StructType, ValueTask<Optional<RefType?>>>(ValueTask.FromResult(result));

            var actual = await source.FlatMapValueAsync(mockMap.Object.Invoke);
            Assert.AreEqual(result, actual);
        }
    }
}
