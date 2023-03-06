using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Constructor_ExpectIsFirstGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<object?, StructType>(sourceValue);
        Assert.True(taggedUnion.IsFirst);
    }

    [Test]
    public void First_Constructor_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = new TaggedUnion<StructType, RefType>(SomeTextStructType);
        Assert.False(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Constructor_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<object?, RefType>(sourceValue);
        Assert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Constructor_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<object?, RefType>(sourceValue);
        Assert.True(taggedUnion.IsNotNone);
    }
}
