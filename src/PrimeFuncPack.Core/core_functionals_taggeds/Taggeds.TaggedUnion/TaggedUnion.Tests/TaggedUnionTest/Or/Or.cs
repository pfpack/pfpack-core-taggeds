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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void Or_OtherFactoryIsNull_ExpectArgumentNullException(
            TaggedUnion<RefType, StructType> source)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Or(null!));
            Assert.AreEqual("otherFactory", ex.ParamName);
        }

        [Test]
        public void Or_SourceIsFirst_ExpectSource()
        {
            var source = TaggedUnion<object, StructType>.First(new object());
            var other = TaggedUnion<object, StructType>.Second(SomeTextStructType);

            var actual = source.Or(() => other);
            Assert.AreEqual(source, actual);
        }

        [Test]
        public void Or_SourceIsSecond_ExpectSource()
        {
            var source = TaggedUnion<object, RefType>.Second(ZeroIdRefType);
            var other = TaggedUnion<object, RefType>.Second(PlusFifteenIdRefType);

            var actual = source.Or(() => other);
            Assert.AreEqual(source, actual);
        }

        [Test]
        public void Or_SourceIsDefault_ExpectOther()
        {
            var source = default(TaggedUnion<object, StructType>);
            var other = TaggedUnion<object, StructType>.First(new object());

            var actual = source.Or(() => other);
            Assert.AreEqual(other, actual);
        }
    }
}
