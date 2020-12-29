#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void ImplicitSecond_ExpectIsFirstGetsFalse()
        {
            TaggedUnion<StructType?, RefType> taggedUnion = ZeroIdRefType;
            Assert.False(taggedUnion.IsFirst);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void ImplicitSecond_ExpectIsSecondGetsTrue(
            object? sourceValue)
        {
            TaggedUnion<StructType, object?> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void ImplicitSecond_ExpectIsInitializedGetsTrue(
            object? sourceValue)
        {
            TaggedUnion<RefType, object?> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsInitialized);
        }
    }
}