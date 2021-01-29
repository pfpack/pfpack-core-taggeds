#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void SecondOrThrow_SourceIsSecond_ExpectSourceValue()
        {
            var sourceValue = MinusFifteenIdRefType;
            TaggedUnion<StructType?, RefType> source = sourceValue;

            var actual = source.SecondOrThrow();
            Assert.AreEqual(sourceValue, actual);
        }

        [Test]
        public void SecondOrThrow_SourceIsFirst_ExpectInvalidOperationException()
        {
            var source = TaggedUnion<object, StructType>.First(new { Text = SomeString });

            var ex = Assert.Throws<InvalidOperationException>(() => _ = source.SecondOrThrow());
            AssertContainsFirst(Second, ex!.Message);
        }

        [Test]
        public void SecondOrThrow_SourceIsDefault_ExpectInvalidOperationException()
        {
            var source = default(TaggedUnion<RefType, string>);

            var ex = Assert.Throws<InvalidOperationException>(() => _ = source.SecondOrThrow());
            AssertContainsFirst(Second, ex!.Message);
        }
    }
}