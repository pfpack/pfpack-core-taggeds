using Moq;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void OnAbsent_TUnit_HandlerIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType?>.Present(PlusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("handler"));

        void Test()
            =>
            _ = source.OnAbsent<long>(null!);
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public void OnAbsent_TUnit_SourceIsPresent_ExpectHandlerCalledNever(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc(SomeTextRecordStruct);

        _ = source.OnAbsent(mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(), Times.Never);
    }

    [Test]
    public void OnAbsent_TUnit_SourceIsAbsent_ExpectHandlerCalledOnce()
    {
        var source = Optional<int>.Absent;
        var mockFunc = CreateMockFunc(ZeroIdRefType);

        _ = source.OnAbsent(mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void OnAbsent_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(decimal.One) : Optional<decimal?>.Absent;

        var actual = source.OnAbsent(OnAbsent);
        Assert.That(actual, Is.EqualTo(source));

        static string? OnAbsent()
            =>
            LowerSomeString;
    }

    [Test]
    public void OnAbsentAsync_TUnit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(MinusFifteenIdRefType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAbsentAsync<string>(null!);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public async Task OnAbsentAsync_TUnit_SourceIsPresent_ExpectHandlerAsyncCalledNever(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockFunc = CreateMockFunc(SomeTextStructType);

        _ = await source.OnAbsentAsync(mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(), Times.Never);
    }

    [Test]
    public async Task OnAbsentAsync_TUnit_SourceIsAbsent_ExpectHandlerAsyncCalledOnce()
    {
        var source = Optional<decimal>.Absent;
        var mockFunc = CreateMockFunc(LowerSomeString);

        _ = await source.OnAbsentAsync(mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAbsentAsync_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(ZeroIdRefType) : Optional.Absent<RefType?>();

        var actual = await source.OnAbsentAsync(OnAbsentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task<int> OnAbsentAsync()
            =>
            Task.FromResult(One);
    }

    [Test]
    public void OnAbsentValueAsync_TUnit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<decimal>.Present(decimal.MinusOne);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAbsentValueAsync<RefType?>(null!);
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public async Task OnAbsentValueAsync_TUnit_SourceIsPresent_ExpectHandlerAsyncCalledNever(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc(AnotherTextStructType);

        _ = await source.OnAbsentValueAsync(mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(), Times.Never);
    }

    [Test]
    public async Task OnAbsentValueAsync_TUnit_SourceIsAbsent_ExpectHandlerAsyncCalledOnce()
    {
        var source = Optional<byte>.Absent;
        var mockFunc = CreateMockFunc(PlusFifteenIdLowerSomeStringNameRecord);

        _ = await source.OnAbsentValueAsync(mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAbsentValueAsync_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(new object()) : Optional.Absent<object?>();

        var actual = await source.OnAbsentValueAsync(OnAbsentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask<RecordStruct> OnAbsentAsync()
            =>
            new(UpperSomeTextRecordStruct);
    }
}