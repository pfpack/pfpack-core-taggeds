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
    public void On_Unit_OnPresentIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(LowerSomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("onPresent"));

        void Test()
            =>
            _ = source.On(null!, OnElse);

        static Unit OnElse()
            =>
            default;
    }

    [Test]
    public void On_Unit_OnElseIsNull_ExpectArgumentNullException()
    {
        var source = Optional<string>.Present(UpperAnotherString);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("onElse"));

        void Test()
            =>
            _ = source.On(OnPresent, null!);

        static Unit OnPresent(string _)
            =>
            default;
    }

    [Test]
    [TestCase(null)]
    [TestCase(SomeString)]
    public void On_Unit_SourceIsPresent_ExpectOnPresentCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<string?, Unit>(default);

        _ = source.On(mockFunc.Object.Invoke, mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(sourceValue), Times.Once);
    }

    [Test]
    public void On_Unit_SourceIsAbsent_ExpectOnElseCalledOnce()
    {
        var source = Optional<int?>.Absent;
        var mockFunc = CreateMockFunc<int?, Unit>(default);

        _ = source.On(mockFunc.Object.Invoke, mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void On_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(PlusFifteenIdRefType) : Optional<RefType?>.Absent;

        var actual = source.On(OnPresent, OnElse);
        Assert.That(actual, Is.EqualTo(source));

        static Unit OnPresent(RefType? _)
            =>
            default;

        static Unit OnElse()
            =>
            default;
    }

    [Test]
    public void OnAsync_Unit_OnPresentAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RecordType>.Present(MinusFifteenIdSomeStringNameRecord);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onPresentAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAsync(null!, OnElseAsync);

        static Task<Unit> OnElseAsync()
            =>
            Task.FromResult<Unit>(default);
    }

    [Test]
    public void OnAsync_Unit_OnElseAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onElseAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAsync(OnPresentAsync, null!);

        static Task<Unit> OnPresentAsync(StructType _)
            =>
            Task.FromResult<Unit>(default);
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public async Task OnAsync_Unit_SourceIsPresent_ExpectOnPresentAsyncCalledOnce(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<bool?, Unit>(default);

        _ = await source.OnAsync(mockFunc.Object.InvokeAsync, mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(sourceValue), Times.Once);
    }

    [Test]
    public async Task OnAsync_Unit_SourceIsAbsent_ExpectOnElseAsyncCalledOnce()
    {
        var source = Optional<RefType>.Absent;
        var mockFunc = CreateMockFunc<RefType, Unit>(default);

        _ = await source.OnAsync(mockFunc.Object.InvokeAsync, mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAsync_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(MinusFifteenIdNullNameRecord) : Optional.Absent<RecordType>();

        var actual = await source.OnAsync(OnPresentAsync, OnElseAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task<Unit> OnPresentAsync(RecordType _)
            =>
            Task.FromResult<Unit>(default);

        static Task<Unit> OnElseAsync()
            =>
            Task.FromResult<Unit>(default);
    }

    [Test]
    public void OnValueAsync_Unit_OnPresentAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<long>.Present(long.MinValue);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onPresentAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnValueAsync(null!, OnElseAsync);

        static ValueTask<Unit> OnElseAsync()
            =>
            default;
    }

    [Test]
    public void OnValueAsync_Unit_OnElseAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<string>.Present(LowerSomeString);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onElseAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnValueAsync(OnPresentAsync, null!);

        static ValueTask<Unit> OnPresentAsync(string _)
            =>
            default;
    }

    [Test]
    [TestCase(null)]
    [TestCase(PlusFifteen)]
    public async Task OnValueAsync_Unit_SourceIsPresent_ExpectOnPresentAsyncCalledOnce(
        int? sourceValue)
    {
        var source = Optional<int?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<int?, Unit>(default);

        _ = await source.OnValueAsync(mockFunc.Object.InvokeValueAsync, mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(sourceValue), Times.Once);
    }

    [Test]
    public async Task OnValueAsync_Unit_SourceIsAbsent_ExpectOnElseAsyncCalledOnce()
    {
        var source = Optional<RecordStruct>.Absent;
        var mockFunc = CreateMockFunc<RecordStruct, Unit>(default);

        _ = await source.OnValueAsync(mockFunc.Object.InvokeValueAsync, mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnValueAsync_Unit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeString) : Optional.Absent<string>();

        var actual = await source.OnValueAsync(OnPresentAsync, OnElseAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask<Unit> OnPresentAsync(string _)
            =>
            default;

        static ValueTask<Unit> OnElseAsync()
            =>
            default;
    }
}