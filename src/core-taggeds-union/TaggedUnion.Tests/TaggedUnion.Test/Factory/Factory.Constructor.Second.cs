using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Second_ExpectIsFirstGetsFalse()
    {
        var taggedUnion = new TaggedUnion<StructType, RefType?>(PlusFifteenIdRefType);
        ClassicAssert.False(taggedUnion.IsFirst);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_ExpectIsSecondGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<RefType?, object?>(sourceValue);
        ClassicAssert.True(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<StructType, object?>(sourceValue);
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<StructType, object?>(sourceValue);
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
