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
        public void FoldAsyncWithOther_MapFirstAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

            var second = int.MinValue;
            var other = int.MaxValue;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldAsync(null!, _ => Task.FromResult(second), other));

            Assert.AreEqual("mapFirstAsync", ex.ParamName);
        }

        [Test]
        public void FoldAsyncWithOther_MapSecondAsyncIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<StructType, RefType>.First(default);

            var first = new object();
            var other = new object();

            var ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.FoldAsync(_ => Task.FromResult(first), null!, other));

            Assert.AreEqual("mapSecondAsync", ex.ParamName);
        }

        [Test]
        public async Task FoldAsyncWithOther_SourceIsDefault_ExpectOther()
        {
            var source = default(TaggedUnion<RefType?, StructType?>);

            object first = PlusFifteen;
            object second = Zero;
            object other = SomeString;

            var actual = await source.FoldAsync(_ => Task.FromResult(first), _ => Task.FromResult(second), other);
            Assert.AreEqual(other, actual);
        }

        [Test]
        public async Task FoldAsyncWithOther_SourceIsFirst_ExpectFirstResult()
        {
            var source = TaggedUnion<StructType, object>.First(default);

            RefType first = null!;
            var second = ZeroIdRefType;
            var other = PlusFifteenIdRefType;

            var actual = await source.FoldAsync(_ => Task.FromResult(first), _ => Task.FromResult(second), other);
            Assert.AreEqual(first, actual);
        }

        [Test]
        public async Task FoldAsyncWithOther_SourceIsSecond_ExpectSecondResult()
        {
            var source = TaggedUnion<object, RefType?>.Second(PlusFifteenIdRefType);

            StructType? first = SomeTextStructType;
            StructType? second = NullTextStructType;
            StructType? other = null;

            var actual = await source.FoldAsync(_ => Task.FromResult(first), _ => Task.FromResult(second), other);
            Assert.AreEqual(second, actual);
        }
    }
}