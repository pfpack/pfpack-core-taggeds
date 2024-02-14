using Moq;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void On_TUnit_OnPresentIsNull_ExpectArgumentNullException()
    {
        var source = Optional<string>.Present(SomeString);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("onPresent"));

        void Test()
            =>
            _ = source.On(null!, OnElse);

        static StructType OnElse()
            =>
            SomeTextStructType;
    }

    [Test]
    public void On_TUnit_OnElseIsNull_ExpectArgumentNullException()
    {
        var source = Optional<decimal?>.Present(decimal.One);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("onElse"));

        void Test()
            =>
            _ = source.On(OnPresent, null!);

        static RecordType OnPresent(decimal? _)
            =>
            PlusFifteenIdLowerSomeStringNameRecord;
    }

    [Test]
    [TestCase(null)]
    [TestCase(true)]
    public void On_TUnit_SourceIsPresent_ExpectOnPresentCalledOnce(
        bool? sourceValue)
    {
        var source = Optional<bool?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<bool?, RefType>(PlusFifteenIdRefType);

        _ = source.On(mockFunc.Object.Invoke, mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(sourceValue), Times.Once);
    }

    [Test]
    public void On_TUnit_SourceIsAbsent_ExpectOnElseCalledOnce()
    {
        var source = Optional<RecordType>.Absent;
        var mockFunc = CreateMockFunc<RecordType, RecordStruct>(SomeTextRecordStruct);

        _ = source.On(mockFunc.Object.Invoke, mockFunc.Object.Invoke);
        mockFunc.Verify(a => a.Invoke(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public void On_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(SomeTextStructType) : Optional<StructType>.Absent;

        var actual = source.On(OnPresent, OnElse);
        Assert.That(actual, Is.EqualTo(source));

        static string OnPresent(StructType _)
            =>
            SomeString;

        static string OnElse()
            =>
            AnotherString;
    }

    [Test]
    public void OnAsync_TUnit_OnPresentAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<int>.Present(One);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onPresentAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAsync(null!, OnElseAsync);

        static Task<RecordStruct?> OnElseAsync()
            =>
            Task.FromResult<RecordStruct?>(UpperSomeTextRecordStruct);
    }

    [Test]
    public void OnAsync_TUnit_OnElseAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(ZeroIdRefType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onElseAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnAsync(OnPresentAsync, null!);

        static Task<int> OnPresentAsync(RefType _)
            =>
            Task.FromResult(PlusFifteen);
    }

    [Test]
    [TestCase(null)]
    [TestCase(LowerSomeString)]
    public async Task OnAsync_TUnit_SourceIsPresent_ExpectOnPresentAsyncCalledOnce(
        string? sourceValue)
    {
        var source = Optional<string?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<string?, RecordStruct>(SomeTextRecordStruct);

        _ = await source.OnAsync(mockFunc.Object.InvokeAsync, mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(sourceValue), Times.Once);
    }

    [Test]
    public async Task OnAsync_TUnit_SourceIsAbsent_ExpectOnElseAsyncCalledOnce()
    {
        var source = Optional<StructType?>.Absent;
        var mockFunc = CreateMockFunc<StructType?, RefType>(MinusFifteenIdRefType);

        _ = await source.OnAsync(mockFunc.Object.InvokeAsync, mockFunc.Object.InvokeAsync);
        mockFunc.Verify(a => a.InvokeAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnAsync_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(int.MinValue) : Optional.Absent<int>();

        var actual = await source.OnAsync(OnPresentAsync, OnElseAsync);
        Assert.That(actual, Is.EqualTo(source));

        static Task<RecordType> OnPresentAsync(int _)
            =>
            Task.FromResult(ZeroIdNullNameRecord);

        static Task<RecordType> OnElseAsync()
            =>
            Task.FromResult(PlusFifteenIdSomeStringNameRecord);
    }

    [Test]
    public void OnValueAsync_TUnit_OnPresentAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(MinusFifteenIdRefType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onPresentAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnValueAsync(null!, OnElseAsync);

        static ValueTask<decimal> OnElseAsync()
            =>
            new(decimal.MinusOne);
    }

    [Test]
    public void OnValueAsync_TUnit_OnElseAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RecordStruct?>.Present(SomeTextRecordStruct);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("onElseAsync"));

        async Task TestAsync()
            =>
            _ = await source.OnValueAsync(OnPresentAsync, null!);

        static ValueTask<StructType> OnPresentAsync(RecordStruct? _)
            =>
            new(SomeTextStructType);
    }

    [Test]
    [TestCase(null)]
    [TestCase(PlusFifteen)]
    public async Task OnValueAsync_TUnit_SourceIsPresent_ExpectOnPresentAsyncCalledOnce(
        int? sourceValue)
    {
        var source = Optional<int?>.Present(sourceValue);
        var mockFunc = CreateMockFunc<int?, RefType>(MinusFifteenIdRefType);

        _ = await source.OnValueAsync(mockFunc.Object.InvokeValueAsync, mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(sourceValue), Times.Once);
    }

    [Test]
    public async Task OnValueAsync_TUnit_SourceIsAbsent_ExpectOnElseAsyncCalledOnce()
    {
        var source = Optional<string>.Absent;
        var mockFunc = CreateMockFunc<string, RecordStruct>(SomeTextRecordStruct);

        _ = await source.OnValueAsync(mockFunc.Object.InvokeValueAsync, mockFunc.Object.InvokeValueAsync);
        mockFunc.Verify(a => a.InvokeValueAsync(), Times.Once);
    }

    [Test]
    [TestCase(false)]
    [TestCase(true)]
    public async Task OnValueAsync_TUnit_ExpectSource(bool isPresent)
    {
        var source = isPresent ? new(PlusFifteen) : Optional.Absent<int>();

        var actual = await source.OnValueAsync(OnPresentAsync, OnElseAsync);
        Assert.That(actual, Is.EqualTo(source));

        static ValueTask<RecordType> OnPresentAsync(int _)
            =>
            new(ZeroIdNullNameRecord);

        static ValueTask<RecordType> OnElseAsync()
            =>
            new(PlusFifteenIdLowerSomeStringNameRecord);
    }
}