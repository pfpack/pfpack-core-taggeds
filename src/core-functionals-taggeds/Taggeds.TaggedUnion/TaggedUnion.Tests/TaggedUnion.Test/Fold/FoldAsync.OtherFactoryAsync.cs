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
        public void FoldAsyncWithOtherFactoryAsync_MapFirstAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<object, RefType>.First(new object());

            var second = new { Id = 55 };
            var other = new { Id = 35 };

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldAsync(
                    null!, _ => Task.FromResult(second), () => Task.FromResult(other)));

            Assert.AreEqual("mapFirstAsync", ex.ParamName);
        }

        [Test]
        public void FoldAsyncWithOtherFactoryAsync_MapSecondAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<StructType?, object>.First(SomeTextStructType);

            var first = PlusFifteenIdRefType;
            var other = ZeroIdRefType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldAsync(
                    _ => Task.FromResult(first), null!, () => Task.FromResult(other)));

            Assert.AreEqual("mapSecondAsync", ex.ParamName);
        }

        [Test]
        public void FoldAsyncWithOtherFactoryAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<RefType, object>.First(MinusFifteenIdRefType);

            var first = SomeTextStructType;
            var second = NullTextStructType;
            Func<Task<StructType>> otherFactoryAsync = null!;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldAsync(
                    _ => Task.FromResult(first), _ => Task.FromResult(second), otherFactoryAsync));

            Assert.AreEqual("otherFactoryAsync", ex.ParamName);
        }

        [Test]
        public async Task FoldAsyncWithOtherFactoryAsync_SourceIsDefault_ExpectOther()
        {
            var source = default(TaggedUnion<RefType, StructType>);

            var first = PlusFifteen;
            var second = Zero;
            var other = MinusFifteen;

            var actual = await source.FoldAsync(
                _ => Task.FromResult(first), _ => Task.FromResult(second), () => Task.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        public async Task FoldAsyncWithOtherFactoryAsync_SourceIsFirst_ExpectFirstResult()
        {
            var source = TaggedUnion<StructType, int>.First(SomeTextStructType);

            var first = MinusFifteenIdRefType;
            var second = ZeroIdRefType;
            var other = PlusFifteenIdRefType;

            var actual = await source.FoldAsync(
                _ => Task.FromResult(first), _ => Task.FromResult(second), () => Task.FromResult(other));

            Assert.AreEqual(first, actual);
        }

        [Test]
        public async Task FoldAsyncWithOtherFactoryAsync_SourceIsSecond_ExpectSecondResult()
        {
            var source = TaggedUnion<object, RefType?>.Second(MinusFifteenIdRefType);

            var first = SomeTextStructType;
            var second = new StructType { Text = "second" };
            var other = new StructType { Text = "other" };

            var actual = await source.FoldAsync(
                _ => Task.FromResult(first), _ => Task.FromResult(second), () => Task.FromResult(other));

            Assert.AreEqual(second, actual);
        }
    }
}