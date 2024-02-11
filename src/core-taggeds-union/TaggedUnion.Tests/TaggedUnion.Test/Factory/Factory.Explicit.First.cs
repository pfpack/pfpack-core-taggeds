using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Explicit_ExpectIsFirstGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<object?, StructType>.First(sourceValue);
        ClassicAssert.True(taggedUnion.IsFirst);
    }

    [Test]
    public void First_Explicit_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = TaggedUnion<StructType, RefType>.First(SomeTextStructType);
        ClassicAssert.False(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Explicit_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<object?, RefType>.First(sourceValue);
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Explicit_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<object?, RefType>.First(sourceValue);
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
