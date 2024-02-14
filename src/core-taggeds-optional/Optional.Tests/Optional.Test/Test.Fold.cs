using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Fold_MapIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(null!, () => PlusFifteenIdRefType));
        Assert.That(ex!.ParamName, Is.EqualTo("map"));
    }

    [Test]
    public void Fold_OtherFactoryIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(_ => PlusFifteenIdRefType, null!));
        Assert.That(ex!.ParamName, Is.EqualTo("otherFactory"));
    }

    [Test]
    public void Fold_SourceIsPresent_ExpectMappedResult()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var mapped = PlusFifteenIdRefType;
        var other = MinusFifteenIdRefType;

        var actual = source.Fold(_ => mapped, () => other);
        Assert.That(actual, Is.SameAs(mapped));
    }

    [Test]
    public void Fold_SourceIsAbsent_ExpectOtherResult()
    {
        var source = Optional<RefType>.Present(PlusFifteenIdRefType);

        var mapped = NullTextStructType;
        var other = SomeTextStructType;

        var actual = source.Fold(_ => mapped, () => other);
        Assert.That(actual, Is.EqualTo(mapped));
    }

    [Test]
    public void FoldAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldAsync(null!, () => Task.FromResult(MinusFifteenIdRefType)));

        Assert.That(ex!.ParamName, Is.EqualTo("mapAsync"));
    }

    [Test]
    public void FoldAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldAsync(_ => Task.FromResult(int.MaxValue), null!));

        Assert.That(ex!.ParamName, Is.EqualTo("otherFactoryAsync"));
    }

    [Test]
    public async Task FoldAsync_SourceIsPresent_ExpectMappedResult()
    {
        var source = Optional<RefType?>.Present(null);

        var mapped = NullTextStructType;
        var other = SomeTextStructType;

        var actual = await source.FoldAsync(_ => Task.FromResult(mapped), () => Task.FromResult(other));
        Assert.That(actual, Is.EqualTo(mapped));
    }

    [Test]
    public async Task FoldAsync_SourceIsAbsent_ExpectOtherResult()
    {
        var source = Optional<StructType>.Present(NullTextStructType);

        var mapped = ThreeWhiteSpacesString;
        var other = SomeString;

        var actual = await source.FoldAsync(_ => Task.FromResult(mapped), () => Task.FromResult(other));
        Assert.That(actual, Is.SameAs(mapped));
    }

    [Test]
    public void FoldValueAsync_MapAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(null!, () => ValueTask.FromResult(MinusFifteenIdRefType)));

        Assert.That(ex!.ParamName, Is.EqualTo("mapAsync"));
    }

    [Test]
    public void FoldValueAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(_ => ValueTask.FromResult(int.MaxValue), null!));

        Assert.That(ex!.ParamName, Is.EqualTo("otherFactoryAsync"));
    }

    [Test]
    public async Task FoldValueAsync_SourceIsPresent_ExpectMappedResult()
    {
        var source = Optional<StructType?>.Present(null);

        var mapped = PlusFifteenIdRefType;
        var other = MinusFifteenIdRefType;

        var actual = await source.FoldValueAsync(_ => ValueTask.FromResult(mapped), () => ValueTask.FromResult(other));
        Assert.That(actual, Is.SameAs(mapped));
    }

    [Test]
    public async Task FoldValueAsync_SourceIsAbsent_ExpectOtherResult()
    {
        var source = Optional<StructType?>.Present(NullTextStructType);

        var mapped = PlusFifteenIdRefType;
        var other = MinusFifteenIdRefType;

        var actual = await source.FoldValueAsync(_ => ValueTask.FromResult(mapped), () => ValueTask.FromResult(other));
        Assert.That(actual, Is.SameAs(mapped));
    }
}
