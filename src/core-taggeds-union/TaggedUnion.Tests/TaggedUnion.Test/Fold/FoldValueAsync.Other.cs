using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void FoldValueAsyncWithOther_MapFirstAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

        var second = 153;
        var other = -201;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(null!, _ => ValueTask.FromResult(second), other));

        Assert.AreEqual("mapFirstAsync", ex!.ParamName);
    }

    [Test]
    public void FoldValueAsyncWithOther_MapSecondAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

        var first = new object();
        var other = new object();

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(_ => ValueTask.FromResult(first), null!, other));

        Assert.AreEqual("mapSecondAsync", ex!.ParamName);
    }

    [Test]
    public async Task FoldValueAsyncWithOther_SourceIsDefault_ExpectOther()
    {
        var source = default(TaggedUnion<RefType?, StructType?>);

        var first = new object();
        var second = new object();
        var other = new { Name = "Some Name" };

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(first), _ => ValueTask.FromResult(second), other);

        Assert.AreEqual(other, actual);
    }

    [Test]
    public async Task FoldValueAsyncWithOther_SourceIsFirst_ExpectFirstResult()
    {
        var source = TaggedUnion<StructType, object>.First(SomeTextStructType);

        var second = ZeroIdRefType;
        var other = PlusFifteenIdRefType;

        var actual = await source.FoldValueAsync(
            static _ => default(ValueTask<RefType>), _ => ValueTask.FromResult(second), other);

        Assert.IsNull(actual);
    }

    [Test]
    public async Task FoldValueAsyncWithOther_SourceIsSecond_ExpectSecondResult()
    {
        var source = TaggedUnion<object, RefType?>.Second(PlusFifteenIdRefType);

        StructType? first = SomeTextStructType;
        StructType? second = NullTextStructType;
        StructType? other = null;

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(first),
            _ => ValueTask.FromResult(second),
            other);

        Assert.AreEqual(second, actual);
    }
}
