using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void FoldWithOther_MapFirstIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

        var second = int.MinValue;
        var other = int.MaxValue;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(null!, _ => second, other));
        ClassicAssert.AreEqual("mapFirst", ex!.ParamName);
    }

    [Test]
    public void FoldWithOther_MapSecondIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

        var first = SomeString;
        var other = TabString;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(_ => first, null!, other));
        ClassicAssert.AreEqual("mapSecond", ex!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void FoldWithOther_SourceIsDefault_ExpectOther(
        object? other)
    {
        var source = default(TaggedUnion<RefType, object>);

        var first = new object();
        var second = new { Id = 251 };

        var actual = source.Fold(_ => first, _ => second, other);
        ClassicAssert.AreEqual(other, actual);
    }

    [Test]
    public void FoldWithOther_SourceIsFirst_ExpectFirstResult()
    {
        var source = TaggedUnion<object, StructType?>.First(new object());

        var first = MinusFifteenIdRefType;
        var second = ZeroIdRefType;
        var other = PlusFifteenIdRefType;

        var actual = source.Fold(_ => first, _ => second, other);
        ClassicAssert.AreEqual(first, actual);
    }

    [Test]
    public void FoldWithOther_SourceIsSecond_ExpectSecondResult()
    {
        var source = TaggedUnion<RefType, StructType>.Second(SomeTextStructType);

        var first = new object();
        object? second = null;
        var other = PlusFifteenIdRefType;

        var actual = source.Fold(_ => first, _ => second, other);
        ClassicAssert.AreEqual(second, actual);
    }
}
