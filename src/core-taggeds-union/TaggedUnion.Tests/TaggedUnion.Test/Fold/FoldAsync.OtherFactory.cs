using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void FoldAsyncWithOtherFactory_MapFirstAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

        var second = new { Text = SomeString };
        var other = new { Text = EmptyString };

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldAsync(null!, _ => Task.FromResult(second), () => other));

        ClassicAssert.AreEqual("mapFirstAsync", ex!.ParamName);
    }

    [Test]
    public void FoldAsyncWithOtherFactory_MapSecondAsyncIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType?, object>.First(null);

        var first = PlusFifteenIdRefType;
        var other = ZeroIdRefType;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldAsync(_ => Task.FromResult(first), null!, () => other));

        ClassicAssert.AreEqual("mapSecondAsync", ex!.ParamName);
    }

    [Test]
    public void FoldAsyncWithOtherFactory_OtherFactoryIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType?, object>.First(null);

        var first = PlusFifteenIdRefType;
        var second = ZeroIdRefType;
        Func<RefType> otherFactory = null!;

        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldAsync(
                _ => Task.FromResult(first), _ => Task.FromResult(second), otherFactory));

        ClassicAssert.AreEqual("otherFactory", ex!.ParamName);
    }

    [Test]
    public async Task FoldAsyncWithOtherFactory_SourceIsDefault_ExpectOther()
    {
        var source = default(TaggedUnion<RefType, StructType>);

        object first = PlusFifteen;
        object second = Zero;
        var other = new object();

        var actual = await source.FoldAsync(
            _ => Task.FromResult(first), _ => Task.FromResult(second), () => other);

        ClassicAssert.AreEqual(other, actual);
    }

    [Test]
    public async Task FoldAsyncWithOtherFactory_SourceIsFirst_ExpectFirstResult()
    {
        var source = TaggedUnion<StructType, object>.First(SomeTextStructType);

        var first = MinusFifteenIdRefType;
        var second = ZeroIdRefType;
        var other = PlusFifteenIdRefType;

        var actual = await source.FoldAsync(
            _ => Task.FromResult(first), _ => Task.FromResult(second), () => other);

        ClassicAssert.AreEqual(first, actual);
    }

    [Test]
    public async Task FoldAsyncWithOtherFactory_SourceIsSecond_ExpectSecondResult()
    {
        var source = TaggedUnion<object, RefType?>.Second(MinusFifteenIdRefType);

        var first = SomeTextStructType;
        var second = NullTextStructType;
        var other = new StructType { Text = "other-text" };

        var actual = await source.FoldAsync(
            _ => Task.FromResult(first), _ => Task.FromResult(second), () => other);

        ClassicAssert.AreEqual(second, actual);
    }
}
