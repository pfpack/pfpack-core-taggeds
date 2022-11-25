using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Bind_MapIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Bind<StructType>(null!));
        Assert.AreEqual("binder", ex?.ParamName);
    }

    [Test]
    public void Bind_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var result = Optional<RefType>.Present(PlusFifteenIdRefType);

        var actual = source.Bind(_ => result);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void Bind_SourceIsPresent_ExpectResultValue(
        bool isResultPresent)
    {
        var source = Optional<StructType?>.Present(SomeTextStructType);
        var result = isResultPresent ? Optional<RefType?>.Present(PlusFifteenIdRefType) : Optional<RefType?>.Absent;

        var actual = source.Bind(_ => result);
        Assert.AreEqual(result, actual);
    }

    [Test]
    public void BindAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);
        Assert.AreEqual("binderAsync", ex?.ParamName);

        async Task TestAsync()
            =>
            _ = await source.BindAsync<int>(null!);
    }

    [Test]
    public async Task BindAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<StructType?>.Absent;
        var result = Optional<RefType>.Present(PlusFifteenIdRefType);

        var actual = await source.BindAsync(_ => Task.FromResult(result));
        Assert.True(actual.IsAbsent);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task BindAsync_SourceIsPresent_ExpectResultValue(
        bool isResultPresent)
    {
        var source = Optional<RefType?>.Present(null);
        var result = isResultPresent ? Optional<StructType?>.Present(SomeTextStructType) : Optional<StructType?>.Absent;

        var actual = await source.BindAsync(_ => Task.FromResult(result));
        Assert.AreEqual(result, actual);
    }

    [Test]
    public void BindValueAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<RefType?>.Present(PlusFifteenIdRefType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(TestAsync);
        Assert.AreEqual("binderAsync", ex?.ParamName);

        async Task TestAsync()
            =>
            _ = await source.BindValueAsync<int>(null!);
    }

    [Test]
    public async Task BindValueAsync_SourceIsAbsent_ExpectAbsent()
    {
        var source = Optional<RefType>.Absent;
        var result = Optional<StructType>.Present(SomeTextStructType);

        var actual = await source.BindValueAsync(_ => ValueTask.FromResult(result));
        Assert.True(actual.IsAbsent);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task BindValueAsync_SourceIsPresent_ExpectResultValue(
        bool isResultPresent)
    {
        var source = Optional<StructType>.Present(default);
        var result = isResultPresent ? Optional<RefType?>.Present(MinusFifteenIdRefType) : Optional<RefType?>.Absent;

        var actual = await source.BindValueAsync(_ => ValueTask.FromResult(result));
        Assert.AreEqual(result, actual);
    }
}
