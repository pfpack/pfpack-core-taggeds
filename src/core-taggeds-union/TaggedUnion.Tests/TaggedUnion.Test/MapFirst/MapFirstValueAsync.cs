#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void MapFirstValueAsync_MapFirstValueAsyncFuncIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.MapFirstValueAsync<decimal>(null!));

            Assert.AreEqual("mapFirstAsync", ex!.ParamName);
        }

        [Test]
        public async Task MapFirstValueAsync_SourceIsFirst_ExpectMappedValueFirstUnion()
        {
            object sourceValue = null!;
            var source = TaggedUnion<object, RefType>.First(sourceValue);

            StructType mappedValue = SomeTextStructType;
            var actual = await source.MapFirstValueAsync(_ => ValueTask.FromResult(mappedValue));

            var expected = TaggedUnion<StructType, RefType>.First(mappedValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapFirstValueAsync_SourceIsSecond_ExpectSourceValueSecondUnion()
        {
            var sourceValue = new { Id = 557 };
            var source = TaggedUnion<StructType, object>.Second(sourceValue);

            var mappedValue = ZeroIdRefType;
            var actual = await source.MapFirstValueAsync(_ => ValueTask.FromResult(mappedValue));

            var expected = TaggedUnion<RefType, object>.Second(sourceValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapFirstValueAsync_SourceIsDefault_ExpectDefault()
        {
            var source = new TaggedUnion<object, RefType?>();

            var mappedValue = PlusFifteenIdRefType;
            var actual = await source.MapFirstValueAsync(_ => ValueTask.FromResult(mappedValue));

            var expected = default(TaggedUnion<RefType, RefType?>);
            Assert.AreEqual(expected, actual);
        }
    }
}