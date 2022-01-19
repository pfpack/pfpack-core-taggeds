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
        Assert.True(taggedUnion.IsFirst);
    }

    [Test]
    public void First_Explicit_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = TaggedUnion<StructType, RefType>.First(SomeTextStructType);
        Assert.False(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Explicit_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<object?, RefType>.First(sourceValue);
        Assert.False(taggedUnion.IsNone);
    }
}
