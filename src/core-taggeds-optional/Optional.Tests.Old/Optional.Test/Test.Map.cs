using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Map_MapIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Map<int>(null!));
        Assert.That(ex!.ParamName, Is.EqualTo("map"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Map_SourceIsPresent_ExpectMappedPresentValue(
        object? mapped)
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var actual = source.Map(_ => mapped);
        var expected = Optional<object?>.Present(mapped);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Map_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var mapped = NullTextStructType;

        var actual = source.Map(_ => mapped);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MapAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapAsync<decimal>(null!));

        Assert.That(ex!.ParamName, Is.EqualTo("mapAsync"));
    }

    [Test]
    public async Task MapAsync_SourceIsPresent_ExpectMappedPresentResult()
    {
        var source = Optional<RefType?>.Present(null);
        var mapped = NullTextStructType;

        var actual = await source.MapAsync(_ => Task.FromResult(mapped));
        var expected = Optional<StructType>.Present(mapped);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public async Task MapAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<StructType>.Absent;
        var mapped = SomeString;

        var actual = await source.MapAsync(_ => Task.FromResult(mapped));
        var expected = Optional<string>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MapValueAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.MapValueAsync<long>(null!));
        Assert.That(ex!.ParamName, Is.EqualTo("mapAsync"));
    }

    [Test]
    public async Task MapValueAsync_SourceIsPresent_ExpectMappedPresentResult()
    {
        var source = Optional<StructType?>.Present(SomeTextStructType);
        var mapped = MinusFifteenIdRefType;

        var actual = await source.MapValueAsync(_ => ValueTask.FromResult(mapped));
        var expected = Optional<RefType>.Present(mapped);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public async Task MapValueAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<StructType?>.Absent;
        var mapped = PlusFifteenIdRefType;

        var actual = await source.MapValueAsync(_ => ValueTask.FromResult(mapped));
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
