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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void First_ExpectIsFirstGetsTrue(
            in object? sourceValue)
        {
            var taggedUnion = TaggedUnion<object?, StructType>.First(sourceValue);
            Assert.IsTrue(taggedUnion.IsFirst);
        }

        [Test]
        public void First_ExpectIsSecondGetsFalse()
        {
            var taggedUnion = TaggedUnion<StructType, RefType>.First(SomeTextStructType);
            Assert.IsFalse(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void First_ExpectIsInitializedGetsTrue(
            in object? sourceValue)
        {
            var taggedUnion = TaggedUnion<object?, RefType>.First(sourceValue);
            Assert.IsTrue(taggedUnion.IsInitialized);
        }
    }
}
