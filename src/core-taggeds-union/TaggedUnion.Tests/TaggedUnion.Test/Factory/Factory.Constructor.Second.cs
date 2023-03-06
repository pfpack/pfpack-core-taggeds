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
    public void Second_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<StructType, object?>(sourceValue);
        Assert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<StructType, object?>(sourceValue);
        Assert.True(taggedUnion.IsNotNone);
    }
}
