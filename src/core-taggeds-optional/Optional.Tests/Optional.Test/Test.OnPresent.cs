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
    public void OnPresent_HandlerIsNull_ExpectArgumentNullException()
    {
        Action<RecordStruct> handler = null!;

        var source = Optional<RecordStruct>.Present(SomeTextRecordStruct);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("handler"));

        void Test()
            =>
            _ = source.OnPresent(handler);
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public void OnPresent_SourceIsPresent_ExpectHandlerCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = source.OnPresent(mockAction.Object.Invoke);
        mockAction.Verify(a => a.Invoke(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void OnPresent_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextStructType) : Optional<StructType>.Absent;

        var actual = source.OnPresent(OnPresent);
        Assert.That(actual, Is.EqualTo(source));

        static void OnPresent(StructType _)
        {
        }
    }

    [Test]
    public void OnPresentAsync_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<long?, Task> handlerAsync = null!;

        var source = Optional<long?>.Present(long.MaxValue);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnPresentAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public async Task OnPresentAsync_SourceIsPresent_ExpectHandlerAsyncCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = await source.OnPresentAsync(mockAction.Object.InvokeAsync);
        mockAction.Verify(a => a.InvokeAsync(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnPresentAsync_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextRecordStruct) : Optional.Absent<RecordStruct?>();

        var actual = await source.OnPresentAsync(OnPresentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task OnPresentAsync(RecordStruct? _)
            =>
            Task.CompletedTask;
    }

    [Test]
    public void OnPresentValueAsync_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<int, ValueTask> handlerAsync = null!;

        var source = Optional<int>.Present(MinusOne);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnPresentValueAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public async Task OnPresentValueAsync_SourceIsPresent_ExpectHandlerAsyncCalledOnce(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = await source.OnPresentValueAsync(mockAction.Object.InvokeValueAsync);
        mockAction.Verify(a => a.InvokeValueAsync(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnPresentValueAsync_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(ZeroIdRefType) : Optional.Absent<RefType>();

        var actual = await source.OnPresentValueAsync(OnPresentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask OnPresentAsync(RefType _)
            =>
            ValueTask.CompletedTask;
    }
}