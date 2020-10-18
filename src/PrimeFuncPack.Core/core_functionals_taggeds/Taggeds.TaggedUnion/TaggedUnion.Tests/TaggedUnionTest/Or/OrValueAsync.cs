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
        public void OrValueAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.OrValueAsync(null!));
            Assert.AreEqual("otherFactoryAsync", ex.ParamName);
        }

        [Test]
        public async Task OrValueAsync_SourceIsFirst_ExpectSource()
        {
            var source = TaggedUnion<StructType, DateTime>.First(SomeTextStructType);
            var other = default(TaggedUnion<StructType, DateTime>);

            var actual = await source.OrValueAsync(() => ValueTask.FromResult(other));
            Assert.AreEqual(source, actual);
        }

        [Test]
        public async Task OrValueAsync_SourceIsSecond_ExpectSource()
        {
            var source = TaggedUnion<object, StructType>.Second(default);
            var other = TaggedUnion<object, StructType>.Second(SomeTextStructType);

            var actual = await source.OrValueAsync(() => ValueTask.FromResult(other));
            Assert.AreEqual(source, actual);
        }

        [Test]
        public async Task OrValueAsync_SourceIsDefault_ExpectOther()
        {
            var source = new TaggedUnion<RefType, object>();
            var other = TaggedUnion<RefType, object>.First(MinusFifteenIdRefType);

            var actual = await source.OrValueAsync(() => ValueTask.FromResult(other));
            Assert.AreEqual(other, actual);
        }
    }
}