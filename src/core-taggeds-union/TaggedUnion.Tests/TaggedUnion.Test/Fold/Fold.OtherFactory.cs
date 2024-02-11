using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void FoldWithOtherFactory_MapFirstIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType, object?>.First(SomeTextStructType);

        var second = PlusFifteenIdRefType;
        var other = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(null!, _ => second, () => other));
        ClassicAssert.AreEqual("mapFirst", ex!.ParamName);
    }

    [Test]
    public void FoldWithOtherFactory_MapSecondIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

        var first = new object();
        var other = new object();

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(_ => first, null!, () => other));
        ClassicAssert.AreEqual("mapSecond", ex!.ParamName);
    }

    [Test]
    public void FoldWithOtherFactory_OtherFactoryIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

        var first = decimal.MinValue;
        var second = decimal.MaxValue;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(_ => first, _ => second, null!));
        ClassicAssert.AreEqual("otherFactory", ex!.ParamName);
    }

    [Test]
    public void FoldWithOtherFactory_SourceIsDefault_ExpectOther()
    {
        var source = default(TaggedUnion<StructType, RefType?>);

        var first = new object();
        var second = new { Id = 251 };
        var other = new { Id = 515 };

        var actual = source.Fold(_ => first, _ => second, () => other);
        ClassicAssert.AreEqual(other, actual);
    }

    [Test]
    public void FoldWithOtherFactory_SourceIsFirst_ExpectFirstResult()
    {
        var source = TaggedUnion<StructType?, RefType>.First(null);

        int? first = null;
        var second = Zero;
        var other = int.MinValue;

        var actual = source.Fold(_ => first, _ => second, () => other);
        ClassicAssert.AreEqual(first, actual);
    }

    [Test]
    public void FoldWithOtherFactory_SourceIsSecond_ExpectSecondResult()
    {
        var source = TaggedUnion<int, object>.Second(new object());

        var first = ZeroIdRefType;
        var second = MinusFifteenIdRefType;
        var other = PlusFifteenIdRefType;

        var actual = source.Fold(_ => first, _ => second, () => other);
        ClassicAssert.AreEqual(second, actual);
    }
}
