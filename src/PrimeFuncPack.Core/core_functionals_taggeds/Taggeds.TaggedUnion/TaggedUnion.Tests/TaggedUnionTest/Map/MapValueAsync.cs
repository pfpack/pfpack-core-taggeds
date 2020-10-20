#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void MapValueAsync_MapFirstAsyncFuncIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.MapValueAsync<byte, int>(null!, _ => ValueTask.FromResult(157)));

            Assert.AreEqual("mapFirstAsync", ex.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void MapValueAsync_MapSecondAsyncFuncIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.MapValueAsync<uint, DateTime>(_ => ValueTask.FromResult<uint>(1), null!));

            Assert.AreEqual("mapSecondAsync", ex.ParamName);
        }

        [Test]
        public async Task MapValueAsync_SourceIsFirst_ExpectMapppedValueFirstUnion()
        {
            var sourceValue = new object();
            var source = TaggedUnion<object, DateTime>.First(sourceValue);

            var mappedFirst = NullTextStructType;
            var mappedSecond = ZeroIdRefType;

            var actual = await source.MapValueAsync(
                _ => ValueTask.FromResult(mappedFirst),
                _ => ValueTask.FromResult(mappedSecond));

            var expected = TaggedUnion<StructType, RefType>.First(mappedFirst);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapValueAsync_SourceIsSecond_ExpectMappedValueSecondUnion()
        {
            var sourceValue = default(StructType);
            var source = TaggedUnion<int, StructType>.Second(sourceValue);

            var mappedFirst = new DateTime(2017, 11, 21);
            object? mappedSecond = null;

            var actual = await source.MapValueAsync(
                _ => ValueTask.FromResult(mappedFirst),
                _ => ValueTask.FromResult(mappedSecond));

            var expected = TaggedUnion<DateTime, object?>.Second(mappedSecond);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task MapValueAsync_SourceIsDefault_ExpectDefault()
        {
            var source = default(TaggedUnion<RefType, int>);

            var mappedFirst = SomeTextStructType;
            var mappedSecond = new object();

            var actual = await source.MapValueAsync(
                _ => ValueTask.FromResult(mappedFirst),
                _ => ValueTask.FromResult(mappedSecond));

            var expected = default(TaggedUnion<StructType, object>);
            Assert.AreEqual(expected, actual);
        }
    }
}