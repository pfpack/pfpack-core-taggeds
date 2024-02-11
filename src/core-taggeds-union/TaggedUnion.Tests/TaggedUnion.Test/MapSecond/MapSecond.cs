using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void MapSecond_MapSecondFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.MapSecond<object>(null!));
        ClassicAssert.AreEqual("mapSecond", ex!.ParamName);
    }

    [Test]
    public void MapSecond_SourceIsFirst_ExpectSourceValueFirstUnion()
    {
        var sourceValue = SomeTextStructType;
        var source = TaggedUnion<StructType?, object?>.First(sourceValue);

        var mappedValue = MinusFifteenIdRefType;
        var actual = source.MapSecond(_ => mappedValue);

        var expected = TaggedUnion<StructType?, RefType>.First(sourceValue);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void MapSecond_SourceIsSecond_ExpectMappedValueSecondUnion()
    {
        var sourceValue = new object();
        var source = TaggedUnion<StructType, object>.Second(sourceValue);

        var mappedValue = MinusFifteenIdRefType;
        var actual = source.MapSecond(_ => mappedValue);

        var expected = TaggedUnion<StructType, RefType>.Second(mappedValue);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void MapSecond_SourceIsDefault_ExpectDefault()
    {
        var source = default(TaggedUnion<StructType, RefType>);

        var mappedValue = MinusFifteen;
        var actual = source.MapSecond(_ => mappedValue);

        var expected = default(TaggedUnion<StructType, int>);
        ClassicAssert.AreEqual(expected, actual);
    }
}
