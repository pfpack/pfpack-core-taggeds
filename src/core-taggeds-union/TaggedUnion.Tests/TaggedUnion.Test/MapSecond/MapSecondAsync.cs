using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void MapSecondAsync_MapSecondAsyncFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapSecondAsync<int>(null!));

        ClassicAssert.AreEqual("mapSecondAsync", ex!.ParamName);
    }

    [Test]
    public async Task MapSecondAsync_SourceIsFirst_ExpectSourceValueFirstUnion()
    {
        RefType? sourceValue = null;
        var source = TaggedUnion<RefType?, object>.First(sourceValue);

        var mappedValue = SomeTextStructType;
        var actual = await source.MapSecondAsync(_ => Task.FromResult(mappedValue));

        var expected = TaggedUnion<RefType?, StructType>.First(sourceValue);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public async Task MapSecondAsync_SourceIsSecond_ExpectMapppedValueSecondUnion()
    {
        var sourceValue = SomeTextStructType;
        var source = TaggedUnion<string, StructType>.Second(sourceValue);

        var mappedValue = new object();
        var actual = await source.MapSecondAsync(_ => Task.FromResult(mappedValue));

        var expected = TaggedUnion<string, object>.Second(mappedValue);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public async Task MapSecondAsync_SourceIsDefault_ExpectDefault()
    {
        var source = default(TaggedUnion<object, int>);

        var mappedValue = SomeTextStructType;
        var actual = await source.MapSecondAsync(_ => Task.FromResult(mappedValue));

        var expected = default(TaggedUnion<object, StructType>);
        ClassicAssert.AreEqual(expected, actual);
    }
}
