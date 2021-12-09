using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void FoldValueAsyncWithOtherFactoryAsync_MapFirstAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

        var second = new { Id = 211 };
        var other = new { Id = -75 };

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(
                null!, _ => ValueTask.FromResult(second), () => ValueTask.FromResult(other)));

        Assert.AreEqual("mapFirstAsync", ex!.ParamName);
    }

    [Test]
    public void FoldValueAsyncWithOtherFactoryAsync_MapSecondAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(MinusFifteenIdRefType);

        var first = new object();
        var other = new { Name = "Some Name" };

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(
                _ => ValueTask.FromResult(first), null!, () => ValueTask.FromResult(other)));

        Assert.AreEqual("mapSecondAsync", ex!.ParamName);
    }

    [Test]
    public void FoldValueAsyncWithOtherFactoryAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<object, RefType>.First(new { Id = 211 });

        var first = SomeTextStructType;
        var second = NullTextStructType;
        Func<ValueTask<StructType>> otherFactoryAsync = null!;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(
                _ => ValueTask.FromResult(first), _ => ValueTask.FromResult(second), otherFactoryAsync));

        Assert.AreEqual("otherFactoryAsync", ex!.ParamName);
    }

    [Test]
    public async Task FoldValueAsyncWithOtherFactoryAsync_SourceIsDefault_ExpectOther()
    {
        var source = default(TaggedUnion<RefType, StructType>);

        var first = PlusFifteen;
        var second = Zero;
        var other = 355;

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(first),
            _ => ValueTask.FromResult(second),
            () => ValueTask.FromResult(other));

        Assert.AreEqual(other, actual);
    }

    [Test]
    public async Task FoldValueAsyncWithOtherFactoryAsync_SourceIsFirst_ExpectFirstResult()
    {
        var source = TaggedUnion<StructType, DateTime>.First(SomeTextStructType);

        var first = MinusFifteenIdRefType;
        var second = ZeroIdRefType;
        var other = PlusFifteenIdRefType;

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(first),
            _ => ValueTask.FromResult(second),
            () => ValueTask.FromResult(other));

        Assert.AreEqual(first, actual);
    }

    [Test]
    public async Task FoldValueAsyncWithOtherFactoryAsync_SourceIsSecond_ExpectSecondResult()
    {
        var source = TaggedUnion<decimal, RefType>.Second(MinusFifteenIdRefType);

        var first = SomeTextStructType;
        var second = new StructType { Text = "second" };
        var other = new StructType { Text = "other" };

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(first),
            _ => ValueTask.FromResult(second),
            () => ValueTask.FromResult(other));

        Assert.AreEqual(second, actual);
    }
}
