using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Second_Implicit_Alt_ExpectIsFirstGetsFalse()
    {
        TaggedUnion<StructType?, RefType> taggedUnion = ZeroIdRefType;
        Assert.False(taggedUnion.IsFirst);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_Alt_ExpectIsSecondGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<StructType, object?> taggedUnion = sourceValue;
        Assert.True(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_Alt_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        TaggedUnion<RefType, object?> taggedUnion = sourceValue;
        Assert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_Alt_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<RefType, object?> taggedUnion = sourceValue;
        Assert.True(taggedUnion.IsNotNone);
    }
}
