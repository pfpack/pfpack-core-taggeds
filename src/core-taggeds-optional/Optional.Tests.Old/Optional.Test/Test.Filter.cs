using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Filter_PredicateIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("predicate"));

        void Test()
            =>
            _ = source.Filter(null!);
    }

    [Test]
    public void Filter_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var actual = source.Filter(static _ => true);

        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public void Filter_SourceIsPresentAndPredicateResultIsFalse_ExpectAbsent()
    {
        var source = Optional<StructType?>.Present(SomeTextStructType);
        var actual = source.Filter(static _ => false);

        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public void Filter_SourceIsPresentAndPredicateResultIsTrue_ExpectPresent()
    {
        var source = Optional<RefType>.Present(ZeroIdRefType);
        var actual = source.Filter(static _ => true);

        Assert.That(actual.IsPresent, Is.True);
    }

    [Test]
    public void FilterAsync_PredicateAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("predicateAsync"));

        async Task TestAsync()
            =>
            _ = await source.FilterAsync(null!);
    }

    [Test]
    public async Task FilterAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<StructType>.Absent;
        var actual = await source.FilterAsync(static _ => Task.FromResult(true));

        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public async Task FilterAsync_SourceIsPresentAndPredicateResultIsFalse_ExpectAbsent()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);
        var actual = await source.FilterAsync(static _ => Task.FromResult(false));

        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public async Task FilterAsync_SourceIsPresentAndPredicateResultIsTrue_ExpectPresent()
    {
        var source = Optional<StructType?>.Present(null);
        var actual = await source.FilterAsync(static _ => Task.FromResult(true));

        Assert.That(actual.IsPresent, Is.True);
    }

    [Test]
    public void FilterValueAsync_PredicateAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType?>.Present(null);
        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);

        Assert.That(ex!.ParamName, Is.EqualTo("predicateAsync"));

        async Task TestAsync()
            =>
            _ = await source.FilterValueAsync(null!);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var actual = await source.FilterValueAsync(static _ => ValueTask.FromResult(true));

        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsPresentAndPredicateResultIsFalse_ExpectAbsent()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);
        var actual = await source.FilterValueAsync(static _ => ValueTask.FromResult(false));

        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public async Task FilterValueAsync_SourceIsPresentAndPredicateResultIsTrue_ExpectPresent()
    {
        var source = Optional<StructType>.Present(default);
        var actual = await source.FilterValueAsync(static _ => ValueTask.FromResult(true));

        Assert.That(actual.IsPresent, Is.True);
    }
}
