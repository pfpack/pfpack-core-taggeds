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
        public void FoldValueAsyncWithOtherFactory_MapFirstAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

            var second = new { Text = SomeString };
            var other = new { Text = EmptyString };

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldValueAsync(null!, _ => ValueTask.FromResult(second), () => other));

            Assert.AreEqual("mapFirstAsync", ex.ParamName);
        }

        [Test]
        public void FoldValueAsyncWithOtherFactory_MapSecondAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<StructType?, object>.First(null);

            var first = PlusFifteenIdRefType;
            var other = ZeroIdRefType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldValueAsync(_ => ValueTask.FromResult(first), null!, () => other));

            Assert.AreEqual("mapSecondAsync", ex.ParamName);
        }

        [Test]
        public void FoldValueAsyncWithOtherFactory_OtherFactoryIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<string, object>.First(SomeString);

            var first = PlusFifteenIdRefType;
            var second = ZeroIdRefType;
            Func<RefType> otherFactory = null!;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldValueAsync(
                    _ => ValueTask.FromResult(first), _ => ValueTask.FromResult(second), otherFactory));

            Assert.AreEqual("otherFactory", ex.ParamName);
        }

        [Test]
        public async Task FoldValueAsyncWithOtherFactory_SourceIsDefault_ExpectOther()
        {
            var source = default(TaggedUnion<RefType, StructType>);

            var first = "first value";
            var second = "second value";
            var other = "other value";

            var actual = await source.FoldValueAsync(
                _ => ValueTask.FromResult(first), _ => ValueTask.FromResult(second), () => other);

            Assert.AreEqual(other, actual);
        }

        [Test]
        public async Task FoldValueAsyncWithOtherFactory_SourceIsFirst_ExpectFirstResult()
        {
            var source = TaggedUnion<StructType, object>.First(SomeTextStructType);

            var first = MinusFifteenIdRefType;
            var second = ZeroIdRefType;
            var other = PlusFifteenIdRefType;

            var actual = await source.FoldValueAsync(
                _ => ValueTask.FromResult(first), _ => ValueTask.FromResult(second), () => other);

            Assert.AreEqual(first, actual);
        }

        [Test]
        public async Task FoldValueAsyncWithOtherFactory_SourceIsSecond_ExpectSecondResult()
        {
            var source = TaggedUnion<object, RefType?>.Second(null);

            var first = new StructType { Text = "first" };
            var second = new StructType { Text = "second" };
            var other = new StructType { Text = "other" };

            var actual = await source.FoldValueAsync(
                _ => ValueTask.FromResult(first), _ => ValueTask.FromResult(second), () => other);

            Assert.AreEqual(second, actual);
        }
    }
}