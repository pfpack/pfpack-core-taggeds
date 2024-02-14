using Moq;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void OnAbsent_HandlerIsNull_ExpectArgumentNullException()
    {
        Action handler = null!;

        var source = Optional<int>.Present(MinusOne);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("handler"));

        void Test()
            =>
            _ = source.OnAbsent(handler);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public void OnAbsent_SourceIsPresent_ExpectHandlerCalledNever(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = source.OnAbsent(mockAction.Object.Invoke);
        mockAction.Verify(a => a.Invoke(), Times.Never);
    }

    [Test]
    public void OnAbsent_SourceIsAbsent_ExpectHandlerCalledOnce()
    {
        var source = Optional<RefType?>.Absent;
        var mockAction = new Mock<IAction>();

        _ = source.OnAbsent(mockAction.Object.Invoke);
        mockAction.Verify(a => a.Invoke(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void OnAbsent_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeString) : Optional<string>.Absent;

        var actual = source.OnAbsent(OnAbsent);
        Assert.That(actual, Is.EqualTo(source));

        static void OnAbsent()
        {
        }
    }

    [Test]
    public void OnAbsentAsync_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<Task> handlerAsync = null!;

        var source = Optional<StructType?>.Present(LowerSomeTextStructType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAbsentAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public async Task OnAbsentAsync_SourceIsPresent_ExpectHandlerAsyncCalledNever(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = await source.OnAbsentAsync(mockAction.Object.InvokeAsync);
        mockAction.Verify(a => a.InvokeAsync(), Times.Never);
    }

    [Test]
    public async Task OnAbsentAsync_SourceIsAbsent_ExpectHandlerAsyncCalledOnce()
    {
        var source = Optional<int>.Absent;
        var mockAction = new Mock<IAction>();

        _ = await source.OnAbsentAsync(mockAction.Object.InvokeAsync);
        mockAction.Verify(a => a.InvokeAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAbsentAsync_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(MinusFifteenIdNullNameRecord) : Optional.Absent<RecordType?>();

        var actual = await source.OnAbsentAsync(OnAbsentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task OnAbsentAsync()
            =>
            Task.CompletedTask;
    }

    [Test]
    public void OnAbsentValueAsync_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<ValueTask> handlerAsync = null!;

        var source = Optional<RecordStruct>.Present(SomeTextRecordStruct);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAbsentValueAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(MinusOne)]
    public async Task OnAbsentValueAsync_SourceIsPresent_ExpectHandlerAsyncCalledNever(
        int? sourceValue)
    {
        var source = Optional<int?>.Present(sourceValue);
        var mockAction = new Mock<IAction>();

        _ = await source.OnAbsentValueAsync(mockAction.Object.InvokeValueAsync);
        mockAction.Verify(a => a.InvokeValueAsync(), Times.Never);
    }

    [Test]
    public async Task OnAbsentValueAsync_SourceIsAbsent_ExpectHandlerAsyncCalledOnce()
    {
        var source = Optional<RecordType?>.Absent;
        var mockAction = new Mock<IAction>();

        _ = await source.OnAbsentValueAsync(mockAction.Object.InvokeValueAsync);
        mockAction.Verify(a => a.InvokeValueAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAbsentValueAsync_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(decimal.One) : Optional.Absent<decimal>();

        var actual = await source.OnAbsentValueAsync(OnAbsentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask OnAbsentAsync()
            =>
            ValueTask.CompletedTask;
    }
}