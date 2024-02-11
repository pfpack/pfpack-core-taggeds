using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void Map_MapFirstFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map<object, StructType>(null!, _ => SomeTextStructType));

        ClassicAssert.AreEqual("mapFirst", ex!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void Map_MapSecondFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map<int, StructType>(_ => 275, null!));

        ClassicAssert.AreEqual("mapSecond", ex!.ParamName);
    }

    [Test]
    public void Map_SourceIsFirst_ExpectMapppedValueFirstUnion()
    {
        var sourceValue = SomeTextStructType;
        var source = TaggedUnion<StructType, object?>.First(sourceValue);

        var mappedFirst = MinusFifteenIdRefType;
        var mappedSecond = EmptyString;

        var actual = source.Map(_ => mappedFirst, _ => mappedSecond);

        var expected = TaggedUnion<RefType, string>.First(mappedFirst);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Map_SourceIsSecond_ExpectMappedValueSecondUnion()
    {
        var sourceValue = new object();
        var source = TaggedUnion<int, object>.Second(sourceValue);

        var mappedFirst = SomeString;
        var mappedSecond = ZeroIdRefType;

        var actual = source.Map(_ => mappedFirst, _ => mappedSecond);

        var expected = TaggedUnion<string, RefType>.Second(mappedSecond);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Map_SourceIsDefault_ExpectDefault()
    {
        var source = default(TaggedUnion<object, RefType>);

        var mappedFirst = SomeTextStructType;
        var mappedSecond = int.MaxValue;

        var actual = source.Map(_ => mappedFirst, _ => mappedSecond);

        var expected = default(TaggedUnion<StructType, int>);
        ClassicAssert.AreEqual(expected, actual);
    }
}
