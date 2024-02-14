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
    public void OnPresent_Unit_HandlerIsNull_ExpectArgumentNullException()
    {
        Func<RefType?, Unit> handler = null!;

        var source = Optional<RefType?>.Present(PlusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("handler"));

        void Test()
            =>
            _ = source.OnPresent(handler);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public void OnPresent_Unit_SourceIsPresent_ExpectHandlerCalledOnce(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<bool?, Unit>(default);

        _ = source.OnPresent(mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void OnPresent_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(PlusFifteenIdSomeStringNameRecord) : Optional<RecordType>.Absent;

        var actual = source.OnPresent(OnPresent);
        Assert.That(actual, Is.EqualTo(source));

        static Unit OnPresent(RecordType _)
            =>
            default;
    }

    [Test]
    public void OnPresentAsync_Unit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<decimal, Task<Unit>> handlerAsync = null!;

        var source = Optional<decimal>.Present(decimal.MinusOne);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnPresentAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(AnotherString)]
    public async Task OnPresentAsync_Unit_SourceIsPresent_ExpectHandlerAsyncCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<int?, Unit>(default);

        _ = await source.OnPresentAsync(mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnPresentAsync_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextRecordStruct) : Optional.Absent<RecordStruct>();

        var actual = await source.OnPresentAsync(OnPresentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task<Unit> OnPresentAsync(RecordStruct _)
            =>
            Task.FromResult<Unit>(default);
    }

    [Test]
    public void OnPresentValueAsync_Unit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<int, ValueTask<Unit>> handlerAsync = null!;

        var source = Optional<int>.Present(MinusFifteen);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnPresentValueAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public async Task OnPresentValueAsync_Unit_SourceIsPresent_ExpectHandlerAsyncCalledOnce(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<bool?, Unit>(default);

        _ = await source.OnPresentValueAsync(mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnPresentValueAsync_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(PlusFifteenIdRefType) : Optional.Absent<RefType?>();

        var actual = await source.OnPresentValueAsync(OnPresentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask<Unit> OnPresentAsync(RefType? _)
            =>
            default;
    }
}