using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Filter_PredicateIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Filter(null!));
        Assert.AreEqual("predicate", ex!.ParamName);
    }

    [Test]
    public void Filter_SourceIsAbsent_ExpectNeverCallPredicate()
    {
        var source = Optional<StructType>.Absent;
        var mockPredicate = MockFuncFactory.CreateMockFunc<StructType, bool>(true);

        _ = source.Filter(mockPredicate.Object.Invoke);
        mockPredicate.Verify(p => p.Invoke(It.IsAny<StructType>()), Times.Never);
    }

    [Test]
    public void Filter_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var mockPredicate = MockFuncFactory.CreateMockFunc<RefType, bool>(true);

        var actual = source.Filter(mockPredicate.Object.Invoke);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void Filter_SourceIsPresent_ExpectCallPredicateOnce(
        bool isSourceValueNull)
    {
        var sourceValue = isSourceValueNull ? null : PlusFifteenIdRefType;
        var source = Optional<RefType?>.Present(sourceValue);

        var mockPredicate = MockFuncFactory.CreateMockFunc<RefType?, bool>(false);

        _ = source.Filter(mockPredicate.Object.Invoke);
        mockPredicate.Verify(p => p.Invoke(sourceValue), Times.Once);
    }

    [Test]
    public void Filter_SourceIsPresentAndPredicateResultIsFalse_ExpectAbsent()
    {
        var source = Optional<StructType?>.Present(SomeTextStructType);
        var mockPredicate = MockFuncFactory.CreateMockFunc<StructType?, bool>(false);

        var actual = source.Filter(mockPredicate.Object.Invoke);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    public void Filter_SourceIsPresentAndPredicateResultIsTrue_ExpectPresent()
    {
        var source = Optional<RefType>.Present(ZeroIdRefType);
        var mockPredicate = MockFuncFactory.CreateMockFunc<RefType, bool>(true);

        var actual = source.Filter(mockPredicate.Object.Invoke);
        Assert.True(actual.IsPresent);
    }

    [Test]
    public void FilterAsync_PredicateAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.FilterAsync(null!));
        Assert.AreEqual("predicateAsync", ex!.ParamName);
    }

    [Test]
    public async Task FilterAsync_SourceIsAbsent_ExpectNeverCallPredicateAsync()
    {
        var source = Optional<RefType?>.Absent;
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<RefType?, Task<bool>>(Task.FromResult(true));

        _ = await source.FilterAsync(mockPredicateAsync.Object.Invoke);
        mockPredicateAsync.Verify(p => p.Invoke(It.IsAny<RefType?>()), Times.Never);
    }

    [Test]
    public async Task FilterAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<StructType>.Absent;
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<StructType, Task<bool>>(Task.FromResult(true));

        var actual = await source.FilterAsync(mockPredicateAsync.Object.Invoke);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task FilterAsync_SourceIsPresent_ExpectCallPredicateAsyncOnce(
        bool isSourceValueNull)
    {
        var sourceValue = isSourceValueNull ? null : (StructType?)SomeTextStructType;
        var source = Optional<StructType?>.Present(sourceValue);

        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<StructType?, Task<bool>>(Task.FromResult(false));

        _ = await source.FilterAsync(mockPredicateAsync.Object.Invoke);
        mockPredicateAsync.Verify(p => p.Invoke(sourceValue), Times.Once);
    }

    [Test]
    public async Task FilterAsync_SourceIsPresentAndPredicateResultIsFalse_ExpectAbsent()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<RefType, Task<bool>>(Task.FromResult(false));

        var actual = await source.FilterAsync(mockPredicateAsync.Object.Invoke);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    public async Task FilterAsync_SourceIsPresentAndPredicateResultIsTrue_ExpectPresent()
    {
        var source = Optional<StructType?>.Present(null);
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<StructType?, Task<bool>>(Task.FromResult(true));

        var actual = await source.FilterAsync(mockPredicateAsync.Object.Invoke);
        Assert.True(actual.IsPresent);
    }

    [Test]
    public void FilterValueAsync_PredicateAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType?>.Present(null);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.FilterValueAsync(null!));
        Assert.AreEqual("predicateAsync", ex!.ParamName);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsAbsent_ExpectNeverCallPredicateAsync()
    {
        var source = Optional<StructType?>.Absent;
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<StructType?, ValueTask<bool>>(ValueTask.FromResult(true));

        _ = await source.FilterValueAsync(mockPredicateAsync.Object.Invoke);
        mockPredicateAsync.Verify(p => p.Invoke(It.IsAny<StructType?>()), Times.Never);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<RefType, ValueTask<bool>>(ValueTask.FromResult(true));

        var actual = await source.FilterValueAsync(mockPredicateAsync.Object.Invoke);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task FilterValueAsync_SourceIsPresent_ExpectCallPredicateAsyncOnce(
        bool isSourceValueNull)
    {
        var sourceValue = isSourceValueNull ? null : MinusFifteenIdRefType;
        var source = Optional<RefType?>.Present(sourceValue);

        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<RefType?, ValueTask<bool>>(ValueTask.FromResult(false));

        _ = await source.FilterValueAsync(mockPredicateAsync.Object.Invoke);
        mockPredicateAsync.Verify(p => p.Invoke(sourceValue), Times.Once);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsPresentAndPredicateResultIsFalse_ExpectAbsent()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<StructType, ValueTask<bool>>(ValueTask.FromResult(false));

        var actual = await source.FilterValueAsync(mockPredicateAsync.Object.Invoke);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsPresentAndPredicateResultIsTrue_ExpectPresent()
    {
        var source = Optional<StructType>.Present(default);
        var mockPredicateAsync = MockFuncFactory.CreateMockFunc<StructType, ValueTask<bool>>(ValueTask.FromResult(true));

        var actual = await source.FilterValueAsync(mockPredicateAsync.Object.Invoke);
        Assert.True(actual.IsPresent);
    }
}
