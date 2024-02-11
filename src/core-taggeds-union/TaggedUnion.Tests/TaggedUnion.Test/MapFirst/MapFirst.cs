using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void MapFirst_MapFirstFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.MapFirst<int>(null!));
        ClassicAssert.AreEqual("mapFirst", ex!.ParamName);
    }

    [Test]
    public void MapFirst_SourceIsFirst_ExpectMappedValueFirstUnion()
    {
        var sourceValue = SomeTextStructType;
        var source = TaggedUnion<StructType, object?>.First(sourceValue);

        var mappedValue = MinusFifteenIdRefType;
        var actual = source.MapFirst(_ => mappedValue);

        var expected = TaggedUnion<RefType, object?>.First(mappedValue);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void MapFirst_SourceIsSecond_ExpectSourceValueSecondUnion()
    {
        var sourceValue = new object();
        var source = TaggedUnion<RefType, object?>.Second(sourceValue);

        var mappedValue = SomeString;
        var actual = source.MapFirst(_ => mappedValue);

        var expected = TaggedUnion<string, object?>.Second(sourceValue);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void MapFirst_SourceIsDefault_ExpectDefault()
    {
        var source = new TaggedUnion<RefType, StructType?>();

        var mappedValue = PlusFifteen;
        var actual = source.MapFirst(_ => mappedValue);

        var expected = default(TaggedUnion<int, StructType?>);
        ClassicAssert.AreEqual(expected, actual);
    }
}
