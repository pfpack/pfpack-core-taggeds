using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void MapAsync_MapFirstAsyncFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapAsync<object, string>(null!, _ => Task.FromResult(SomeString)));

        ClassicAssert.AreEqual("mapFirstAsync", ex!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void MapAsync_MapSecondAsyncFuncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapAsync<decimal, object>(_ => Task.FromResult(21.5m), null!));

        ClassicAssert.AreEqual("mapSecondAsync", ex!.ParamName);
    }

    [Test]
    public async Task MapAsync_SourceIsFirst_ExpectMapppedValueFirstUnion()
    {
        var sourceValue = SomeTextStructType;
        var source = TaggedUnion<StructType, object?>.First(sourceValue);

        RefType mappedFirst = null!;
        var mappedSecond = SomeString;

        var actual = await source.MapAsync(_ => Task.FromResult(mappedFirst), _ => Task.FromResult(mappedSecond));

        var expected = TaggedUnion<RefType, string>.First(mappedFirst);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public async Task MapAsync_SourceIsSecond_ExpectMappedValueSecondUnion()
    {
        var sourceValue = SomeTextStructType;
        var source = TaggedUnion<int, StructType>.Second(sourceValue);

        var mappedFirst = MinusFifteenIdRefType;
        object mappedSecond = new { Name = "Some Name" };

        var actual = await source.MapAsync(_ => Task.FromResult(mappedFirst), _ => Task.FromResult(mappedSecond));

        var expected = TaggedUnion<RefType, object>.Second(mappedSecond);
        ClassicAssert.AreEqual(expected, actual);
    }

    [Test]
    public async Task MapAsync_SourceIsDefault_ExpectDefault()
    {
        var source = default(TaggedUnion<object, int>);

        var mappedFirst = SomeTextStructType;
        var mappedSecond = ZeroIdRefType;

        var actual = await source.MapAsync(_ => Task.FromResult(mappedFirst), _ => Task.FromResult(mappedSecond));

        var expected = default(TaggedUnion<StructType, RefType>);
        ClassicAssert.AreEqual(expected, actual);
    }
}
