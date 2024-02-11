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
        ClassicAssert.True(taggedUnion.IsFirst);
    }

    [Test]
    public void First_Constructor_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = new TaggedUnion<StructType, RefType>(SomeTextStructType);
        ClassicAssert.False(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Constructor_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<object?, RefType>(sourceValue);
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Constructor_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<object?, RefType>(sourceValue);
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
