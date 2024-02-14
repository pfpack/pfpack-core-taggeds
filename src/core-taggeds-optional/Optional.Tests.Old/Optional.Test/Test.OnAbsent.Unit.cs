using Moq;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void OnAbsent_Unit_HandlerIsNull_ExpectArgumentNullException()
    {
        Func<Unit> handler = null!;

        var source = Optional<StructType>.Present(LowerSomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("handler"));

        void Test()
            =>
            _ = source.OnAbsent(handler);
    }

    [Test]
    [TestCase(null)]
    [TestCase(MinusOne)]
    public void OnAbsent_Unit_SourceIsPresent_ExpectHandlerCalledNever(
        int? sourceValue)
    {
        var source = Optional<int?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<Unit>(default);

        _ = source.OnAbsent(mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(), Times.Never);
    }

    [Test]
    public void OnAbsent_Unit_SourceIsAbsent_ExpectHandlerCalledOnce()
    {
        var source = Optional<RecordType>.Absent;
        var mockFunc = CreateMockFunc<Unit>(default);

        _ = source.OnAbsent(mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void OnAbsent_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(PlusFifteenIdRefType) : Optional<RefType>.Absent;

        var actual = source.OnAbsent(OnAbsent);
        Assert.That(actual, Is.EqualTo(source));

        static Unit OnAbsent()
            =>
            default;
    }

    [Test]
    public void OnAbsentAsync_Unit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<Task<Unit>> handlerAsync = null!;

        var source = Optional<RecordStruct?>.Present(SomeTextRecordStruct);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAbsentAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(LowerSomeString)]
    public async Task OnAbsentAsync_Unit_SourceIsPresent_ExpectHandlerAsyncCalledNever(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<Unit>(default);

        _ = await source.OnAbsentAsync(mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(), Times.Never);
    }

    [Test]
    public async Task OnAbsentAsync_Unit_SourceIsAbsent_ExpectHandlerAsyncCalledOnce()
    {
        var source = Optional<RefType>.Absent;
        var mockFunc = CreateMockFunc<Unit>(default);

        _ = await source.OnAbsentAsync(mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAbsentAsync_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(MinusFifteenIdSomeStringNameRecord) : Optional.Absent<RecordType>();

        var actual = await source.OnAbsentAsync(OnAbsentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task<Unit> OnAbsentAsync()
            =>
            Task.FromResult<Unit>(default);
    }

    [Test]
    public void OnAbsentValueAsync_Unit_HandlerAsyncIsNull_ExpectArgumentNullException()
    {
        Func<ValueTask<Unit>> handlerAsync = null!;

        var source = Optional<RefType>.Present(PlusFifteenIdRefType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("handlerAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAbsentValueAsync(handlerAsync);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public async Task OnAbsentValueAsync_Unit_SourceIsPresent_ExpectHandlerAsyncCalledNever(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<Unit>(default);

        _ = await source.OnAbsentValueAsync(mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(), Times.Never);
    }

    [Test]
    public async Task OnAbsentValueAsync_Unit_SourceIsAbsent_ExpectHandlerAsyncCalledOnce()
    {
        var source = Optional<string?>.Absent;
        var mockFunc = CreateMockFunc<Unit>(default);

        _ = await source.OnAbsentValueAsync(mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAbsentValueAsync_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextStructType) : Optional.Absent<StructType>();

        var actual = await source.OnAbsentValueAsync(OnAbsentAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask<Unit> OnAbsentAsync()
            =>
            default;
    }
}