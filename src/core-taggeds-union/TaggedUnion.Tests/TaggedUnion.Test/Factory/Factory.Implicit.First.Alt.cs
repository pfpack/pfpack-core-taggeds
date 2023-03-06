using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_Alt_ExpectIsFirstGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<object?, RefType> taggedUnion = sourceValue;
        Assert.True(taggedUnion.IsFirst);
    }

    [Test]
    public void First_Implicit_Alt_ExpectIsSecondGetsFalse()
    {
        TaggedUnion<RefType, StructType> taggedUnion = MinusFifteenIdRefType;
        Assert.False(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_Alt_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        TaggedUnion<object?, StructType> taggedUnion = sourceValue;
        Assert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_Alt_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<object?, StructType> taggedUnion = sourceValue;
        Assert.True(taggedUnion.IsNotNone);
    }
}
