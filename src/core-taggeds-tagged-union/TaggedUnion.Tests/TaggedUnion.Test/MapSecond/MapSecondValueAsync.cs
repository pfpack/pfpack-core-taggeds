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
        public void MapSecondValueAsync_MapSecondValueAsyncFuncIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.MapSecondValueAsync<int>(null!));

            Assert.AreEqual("mapSecondAsync", ex!.ParamName);
        }

        [Test]
        public async Task MapSecondValueAsync_SourceIsFirst_ExpectSourceValueFirstUnion()
        {
            var sourceValue = SomeString;
            var source = TaggedUnion<string, StructType>.First(sourceValue);

            RefType? mappedValue = PlusFifteenIdRefType;
            var actual = await source.MapSecondValueAsync(_ => ValueTask.FromResult(mappedValue));

            var expected = TaggedUnion<string, RefType?>.First(sourceValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapSecondValueAsync_SourceIsSecond_ExpectMapppedValueSecondUnion()
        {
            var sourceValue = SomeTextStructType;
            var source = TaggedUnion<object, StructType>.Second(sourceValue);

            var mappedValue = MinusFifteenIdRefType;
            var actual = await source.MapSecondValueAsync(_ => ValueTask.FromResult(mappedValue));

            var expected = TaggedUnion<object, RefType>.Second(mappedValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapSecondValueAsync_SourceIsDefault_ExpectDefault()
        {
            var source = default(TaggedUnion<StructType, int>);

            var mappedValue = PlusFifteenIdRefType;
            var actual = await source.MapSecondValueAsync(_ => ValueTask.FromResult(mappedValue));

            var expected = new TaggedUnion<StructType, RefType>();
            Assert.AreEqual(expected, actual);
        }
    }
}