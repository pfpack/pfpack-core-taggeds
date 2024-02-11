using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionExtensionsTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
    public void OrInitializeValueAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
        TaggedUnion<RefType, StructType> source)
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await TaggedUnionExtensions.OrInitializeValueAsync(source, null!));
        ClassicAssert.AreEqual("otherFactoryAsync", ex!.ParamName);
    }

    [Test]
    public async Task OrInitializeValueAsync_SourceIsFirst_ExpectSource()
    {
        var source = TaggedUnion<StructType, DateTime>.First(SomeTextStructType);
        var other = default(TaggedUnion<StructType, DateTime>);

        var actual = await TaggedUnionExtensions.OrInitializeValueAsync(source, () => ValueTask.FromResult(other));
        ClassicAssert.AreEqual(source, actual);
    }

    [Test]
    public async Task OrInitializeValueAsync_SourceIsSecond_ExpectSource()
    {
        var source = TaggedUnion<object, StructType>.Second(default);
        var other = TaggedUnion<object, StructType>.Second(SomeTextStructType);

        var actual = await TaggedUnionExtensions.OrInitializeValueAsync(source, () => ValueTask.FromResult(other));
        ClassicAssert.AreEqual(source, actual);
    }

    [Test]
    public async Task OrInitializeValueAsync_SourceIsDefault_ExpectOther()
    {
        var source = new TaggedUnion<RefType, object>();
        var other = TaggedUnion<RefType, object>.First(MinusFifteenIdRefType);

        var actual = await TaggedUnionExtensions.OrInitializeValueAsync(source, () => ValueTask.FromResult(other));
        ClassicAssert.AreEqual(other, actual);
    }
}
