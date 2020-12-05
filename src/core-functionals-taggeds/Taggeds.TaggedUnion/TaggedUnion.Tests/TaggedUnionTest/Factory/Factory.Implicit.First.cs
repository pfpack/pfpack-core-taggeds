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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void First_Implicit_ExpectIsFirstGetsTrue(
            in object? sourceValue)
        {
            TaggedUnion<object?, StructType> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsFirst);
        }

        [Test]
        public void First_Implicit_ExpectIsSecondGetsFalse()
        {
            TaggedUnion<StructType, RefType> taggedUnion = SomeTextStructType;
            Assert.False(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void First_Implicit_ExpectIsInitializedGetsTrue(
            in object? sourceValue)
        {
            TaggedUnion<object?, RefType> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsInitialized);
        }
    }
}
