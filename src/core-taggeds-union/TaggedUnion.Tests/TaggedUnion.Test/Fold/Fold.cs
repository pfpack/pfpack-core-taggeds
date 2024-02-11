using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Fold_MapFirstIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(null!, _ => new object()));
        ClassicAssert.AreEqual("mapFirst", ex!.ParamName);
    }

    [Test]
    public void Fold_MapSecondIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(_ => new object(), null!));
        ClassicAssert.AreEqual("mapSecond", ex!.ParamName);
    }

    [Test]
    public void Fold_SourceIsDefault_ExpectDefault()
    {
        var source = default(TaggedUnion<StructType, object>);

        var first = PlusFifteenIdRefType;
        var second = MinusFifteenIdRefType;

        var actual = source.Fold(_ => first, _ => second);
        ClassicAssert.IsNull(actual);
    }

    [Test]
    public void Fold_SourceIsFirst_ExpectFirstResult()
    {
        var source = TaggedUnion<RefType, object>.First(MinusFifteenIdRefType);

        var first = SomeTextStructType;
        var second = NullTextStructType;

        var actual = source.Fold(_ => first, _ => second);
        ClassicAssert.AreEqual(first, actual);
    }

    [Test]
    public void Fold_SourceIsSecond_ExpectSecondResult()
    {
        var source = TaggedUnion<int, StructType>.Second(SomeTextStructType);

        var first = PlusFifteenIdRefType;
        var second = ZeroIdRefType;

        var actual = source.Fold(_ => first, _ => second);
        ClassicAssert.AreEqual(second, actual);
    }
}
