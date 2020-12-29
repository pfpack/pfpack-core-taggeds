#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void Second_ExpectIsFirstGetsFalse()
        {
            var taggedUnion = new TaggedUnion<StructType, RefType?>(PlusFifteenIdRefType);
            Assert.False(taggedUnion.IsFirst);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Second_ExpectIsSecondGetsTrue(
            object? sourceValue)
        {
            var taggedUnion = new TaggedUnion<RefType?, object?>(sourceValue);
            Assert.True(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Second_ExpectIsInitializedGetsTrue(
            object? sourceValue)
        {
            var taggedUnion = new TaggedUnion<StructType, object?>(sourceValue);
            Assert.True(taggedUnion.IsInitialized);
        }
    }
}