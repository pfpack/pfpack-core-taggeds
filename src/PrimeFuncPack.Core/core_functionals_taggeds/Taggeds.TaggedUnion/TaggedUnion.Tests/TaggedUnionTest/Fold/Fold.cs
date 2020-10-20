#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void Fold_MapFirstIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(null!, _ => new object()));
            Assert.AreEqual("mapFirst", ex.ParamName);
        }

        [Test]
        public void Fold_MapSecondIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Fold(_ => new object(), null!));
            Assert.AreEqual("mapSecond", ex.ParamName);
        }

        [Test]
        public void Fold_SourceIsDefault_ExpectDefault()
        {
            var source = default(TaggedUnion<StructType, object>);

            var first = PlusFifteenIdRefType;
            var second = MinusFifteenIdRefType;

            var actual = source.Fold(_ => first, _ => second);
            Assert.IsNull(actual);
        }

        [Test]
        public void Fold_SourceIsFirst_ExpectFirstResult()
        {
            var source = TaggedUnion<RefType, object>.First(MinusFifteenIdRefType);

            var first = SomeTextStructType;
            var second = NullTextStructType;

            var actual = source.Fold(_ => first, _ => second);
            Assert.AreEqual(first, actual);
        }

        [Test]
        public void Fold_SourceIsSecond_ExpectSecondResult()
        {
            var source = TaggedUnion<int, StructType>.Second(SomeTextStructType);

            var first = PlusFifteenIdRefType;
            var second = ZeroIdRefType;

            var actual = source.Fold(_ => first, _ => second);
            Assert.AreEqual(second, actual);
        }
    }
}
