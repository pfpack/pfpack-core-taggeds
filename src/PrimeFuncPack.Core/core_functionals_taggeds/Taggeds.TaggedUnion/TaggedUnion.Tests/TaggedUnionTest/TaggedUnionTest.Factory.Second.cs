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
        public void Second_ExpectIsFirstGetsFalse()
        {
            var taggedUnion = TaggedUnion<StructType, RefType?>.Second(PlusFifteenIdRefType);
            Assert.IsFalse(taggedUnion.IsFirst);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Second_ExpectIsSecondGetsTrue(
            in object? sourceValue)
        {
            var taggedUnion = TaggedUnion<RefType?, object?>.Second(sourceValue);
            Assert.IsTrue(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Second_ExpectIsInitializedGetsTrue(
            in object? sourceValue)
        {
            var taggedUnion = TaggedUnion<StructType, object?>.Second(sourceValue);
            Assert.IsTrue(taggedUnion.IsInitialized);
        }
    }
}