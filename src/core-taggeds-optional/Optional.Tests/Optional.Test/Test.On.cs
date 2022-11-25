using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void On_OnPresentIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RecordStruct>.Present(SomeTextRecordStruct);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("onPresent", ex?.ParamName);

        void Test()
            =>
            _ = source.On(null!, OnElse);

        static void OnElse()
        {
        }
    }

    [Test]
    public void On_OnElseIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("onElse", ex?.ParamName);

        void Test()
            =>
            _ = source.On(OnPresent, null!);

        static void OnPresent(RefType _)
        {
        }
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public void On_SourceIsPresent_ExpectOnPresentCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = source.On(mockAction.Object.Invoke, mockAction.Object.Invoke);
        mockAction.Verify(a => a.Invoke(sourceValue), Times.Once);
    }

    [Test]
    public void On_SourceIsAbsent_ExpectOnElseCalledOnce()
    {
        var source = Optional<StructType>.Absent;
        var mockAction = new Mock<IAction>();

        _ = source.On(mockAction.Object.Invoke, mockAction.Object.Invoke);
        mockAction.Verify(a => a.Invoke(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void On_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(PlusFifteenIdSomeStringNameRecord) : Optional<RecordType?>.Absent;

        var actual = source.On(OnPresent, OnElse);
        Assert.AreEqual(source, actual);

        static void OnPresent(RecordType? _)
        {
        }

        static void OnElse()
        {
        }
    }

    [Test]
    public void OnAsync_OnPresentAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(MinusFifteenIdRefType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.AreEqual("onPresentAsync", ex?.ParamName);

        async Task TestAsync()
            =>
            _ = await source.OnAsync(null!, OnElseAsync);

        static Task OnElseAsync()
            =>
            Task.CompletedTask;
    }

    [Test]
    public void OnAsync_OnElseAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<long?>.Present(long.MaxValue);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.AreEqual("onElseAsync", ex?.ParamName);

        async Task TestAsync()
            =>
            _ = await source.OnAsync(OnPresentAsync, null!);

        static Task OnPresentAsync(long? _)
            =>
            Task.CompletedTask;
    }

    [Test]
    [TestCase(null)]
    [TestCase(PlusFifteen)]
    public async Task OnAsync_SourceIsPresent_ExpectOnPresentAsyncCalledOnce(
        int? sourceValue)
    {
        var source = Optional<int?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = await source.OnAsync(mockAction.Object.InvokeAsync, mockAction.Object.InvokeAsync);
        mockAction.Verify(a => a.InvokeAsync(sourceValue), Times.Once);
    }

    [Test]
    public async Task OnAsync_SourceIsAbsent_ExpectOnElseAsyncCalledOnce()
    {
        var source = Optional<RecordType>.Absent;
        var mockAction = new Mock<IAction>();

        _ = await source.OnAsync(mockAction.Object.InvokeAsync, mockAction.Object.InvokeAsync);
        mockAction.Verify(a => a.InvokeAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAsync_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextStructType) : Optional.Absent<StructType>();

        var actual = await source.OnAsync(OnPresentAsync, OnElseAsync);
        Assert.AreEqual(source, actual);

        static Task OnPresentAsync(StructType _)
            =>
            Task.CompletedTask;

        static Task OnElseAsync()
            =>
            Task.CompletedTask;
    }

    [Test]
    public void OnValueAsync_OnPresentAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<string>.Present(LowerSomeString);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.AreEqual("onPresentAsync", ex?.ParamName);

        async Task TestAsync()
            =>
            _ = await source.OnValueAsync(null!, OnElseAsync);

        static ValueTask OnElseAsync()
            =>
            ValueTask.CompletedTask;
    }

    [Test]
    public void OnValueAsync_OnElseAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType?>.Present(ZeroIdRefType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.AreEqual("onElseAsync", ex?.ParamName);

        async Task TestAsync()
            =>
            _ = await source.OnValueAsync(OnPresentAsync, null!);

        static ValueTask OnPresentAsync(RefType? _)
            =>
            ValueTask.CompletedTask;
    }

    [Test]
    [TestCase(null)]
    [TestCase(AnotherString)]
    public async Task OnValueAsync_SourceIsPresent_ExpectOnPresentAsyncCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = await source.OnValueAsync(mockAction.Object.InvokeValueAsync, mockAction.Object.InvokeValueAsync);
        mockAction.Verify(a => a.InvokeValueAsync(sourceValue), Times.Once);
    }

    [Test]
    public async Task OnValueAsync_SourceIsAbsent_ExpectOnElseAsyncCalledOnce()
    {
        var source = Optional<RefType>.Absent;
        var mockAction = new Mock<IAction>();

        _ = await source.OnValueAsync(mockAction.Object.InvokeValueAsync, mockAction.Object.InvokeValueAsync);
        mockAction.Verify(a => a.InvokeValueAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnValueAsync_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(MinusFifteenIdSomeStringNameRecord) : Optional.Absent<RecordType?>();

        var actual = await source.OnValueAsync(OnPresentAsync, OnElseAsync);
        Assert.AreEqual(source, actual);

        static ValueTask OnPresentAsync(RecordType? _)
            =>
            ValueTask.CompletedTask;

        static ValueTask OnElseAsync()
            =>
            ValueTask.CompletedTask;
    }
}