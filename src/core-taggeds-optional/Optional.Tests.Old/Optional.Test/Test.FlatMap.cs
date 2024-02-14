using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void FlatMap_MapIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("map"));

        void Test()
            =>
            _ = source.FlatMap<StructType>(null!);
    }

    [Test]
    public void FlatMap_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var result = Optional<RefType>.Present(PlusFifteenIdRefType);

        var actual = source.FlatMap(_ => result);
        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void FlatMap_SourceIsPresent_ExpectResultValue(
        bool isResultPresent)
    {
        var source = Optional<StructType?>.Present(SomeTextStructType);
        var result = isResultPresent ? Optional<RefType?>.Present(PlusFifteenIdRefType) : Optional<RefType?>.Absent;

        var actual = source.FlatMap(_ => result);
        Assert.That(actual, Is.EqualTo(result));
    }

    [Test]
    public void FlatMapAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);
        Assert.That(ex!.ParamName, Is.EqualTo("mapAsync"));

        async Task TestAsync()
            =>
            _ = await source.FlatMapAsync<int>(null!);
    }

    [Test]
    public async Task FlatMapAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<StructType?>.Absent;
        var result = Optional<RefType>.Present(PlusFifteenIdRefType);

        var actual = await source.FlatMapAsync(_ => Task.FromResult(result));
        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task FlatMapAsync_SourceIsPresent_ExpectResultValue(
        bool isResultPresent)
    {
        var source = Optional<RefType?>.Present(null);
        var result = isResultPresent ? Optional<StructType?>.Present(SomeTextStructType) : Optional<StructType?>.Absent;

        var actual = await source.FlatMapAsync(_ => Task.FromResult(result));
        Assert.That(actual, Is.EqualTo(result));
    }

    [Test]
    public void FlatMapValueAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType?>.Present(PlusFifteenIdRefType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);
        Assert.That(ex!.ParamName, Is.EqualTo("mapAsync"));

        async Task TestAsync()
            =>
            _ = await source.FlatMapValueAsync<int>(null!);
    }

    [Test]
    public async Task FlatMapValueAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var result = Optional<StructType>.Present(SomeTextStructType);

        var actual = await source.FlatMapValueAsync(_ => ValueTask.FromResult(result));
        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task FlatMapValueAsync_SourceIsPresent_ExpectResultValue(
        bool isResultPresent)
    {
        var source = Optional<StructType>.Present(default);
        var result = isResultPresent ? Optional<RefType?>.Present(MinusFifteenIdRefType) : Optional<RefType?>.Absent;

        var actual = await source.FlatMapValueAsync(_ => ValueTask.FromResult(result));
        Assert.That(actual, Is.EqualTo(result));
    }
}
