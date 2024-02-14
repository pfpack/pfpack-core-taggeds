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
    public void OnPresent_TUnit_HandlerIsNull_ExpectArgumentNullException()
    {
        var source = Optional<int>.Present(One);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("handler"));

        void Test()
            =>
            _ = source.OnPresent<string?>(null!);
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public void OnPresent_TUnit_SourceIsPresent_ExpectHandlerCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<string?, RecordStruct>(SomeTextRecordStruct);

        _ = source.OnPresent(mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void OnPresent_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(MinusFifteenIdRefType) : Optional<RefType>.Absent;

        var actual = source.OnPresent(OnPresent);
        Assert.That(actual, Is.EqualTo(source));

        static decimal OnPresent(RefType _)
            =>
            decimal.One;
    }

    [Test]
    public void OnPresentAsync_TUnit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RecordType>.Present(MinusFifteenIdSomeStringNameRecord);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnPresentAsync<long>(null!);
    }

    [Test]
    [TestCase(null)]
    [TestCase(PlusFifteen)]
    public async Task OnPresentAsync_TUnit_SourceIsPresent_ExpectHandlerAsyncCalledOnce(
        int? sourceValue)
    {
        var source = Optional<int?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<int?, string>(UpperAnotherString);

        _ = await source.OnPresentAsync(mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnPresentAsync_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(MinusFifteenIdNullNameRecord) : Optional.Absent<RecordType?>();

        var actual = await source.OnPresentAsync(OnPresentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task<decimal> OnPresentAsync(RecordType? _)
            =>
            Task.FromResult(decimal.One);
    }

    [Test]
    public void OnPresentValueAsync_TUnit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<string>.Present(SomeString);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnPresentValueAsync<StructType>(null!);
    }

    [Test]
    [TestCase(null)]
    [TestCase(AnotherString)]
    public async Task OnPresentValueAsync_TUnit_SourceIsPresent_ExpectHandlerAsyncCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<string?, RecordType>(ZeroIdNullNameRecord);

        _ = await source.OnPresentValueAsync(mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(sourceValue), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnPresentValueAsync_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextRecordStruct) : Optional.Absent<RecordStruct>();

        var actual = await source.OnPresentValueAsync(OnPresentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask<int> OnPresentAsync(RecordStruct _)
            =>
            new(PlusFifteen);
    }
}