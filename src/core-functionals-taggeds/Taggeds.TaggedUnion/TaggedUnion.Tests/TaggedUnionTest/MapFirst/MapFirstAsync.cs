#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void MapFirstAsync_MapFirstAsyncFuncIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.MapFirstAsync<int>(null!));

            Assert.AreEqual("mapFirstAsync", ex.ParamName);
        }

        [Test]
        public async Task MapFirstAsync_SourceIsFirst_ExpectMappedValueFirstUnion()
        {
            var sourceValue = ZeroIdRefType;
            var source = TaggedUnion<RefType?, object>.First(sourceValue);

            StructType? mappedValue = null;
            var actual = await source.MapFirstAsync(_ => Task.FromResult(mappedValue));

            var expected = TaggedUnion<StructType?, object>.First(mappedValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapFirstAsync_SourceIsSecond_ExpectSourceValueSecondUnion()
        {
            var sourceValue = new object();
            var source = TaggedUnion<StructType, object?>.Second(sourceValue);

            var mappedValue = EmptyString;
            var actual = await source.MapFirstAsync(_ => Task.FromResult(mappedValue));

            var expected = TaggedUnion<string, object?>.Second(sourceValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapFirstAsync_SourceIsDefault_ExpectDefault()
        {
            var source = new TaggedUnion<object, StructType?>();

            var mappedValue = PlusFifteenIdRefType;
            var actual = await source.MapFirstAsync(_ => Task.FromResult(mappedValue));

            var expected = default(TaggedUnion<RefType, StructType?>);
            Assert.AreEqual(expected, actual);
        }
    }
}