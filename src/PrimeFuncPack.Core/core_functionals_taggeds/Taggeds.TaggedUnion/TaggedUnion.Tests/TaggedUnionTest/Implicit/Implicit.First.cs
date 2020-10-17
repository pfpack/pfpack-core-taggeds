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
        public void ImplicitFirst_ExpectIsFirstGetsTrue(
            in object? sourceValue)
        {
            TaggedUnion<object?, RefType> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsFirst);
        }

        [Test]
        public void ImplicitFirst_ExpectIsSecondGetsFalse()
        {
            TaggedUnion<RefType, StructType> taggedUnion = MinusFifteenIdRefType;
            Assert.False(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void ImplicitFirst_ExpectIsInitializedGetsTrue(
            in object? sourceValue)
        {
            TaggedUnion<object?, StructType> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsInitialized);
        }
    }
}