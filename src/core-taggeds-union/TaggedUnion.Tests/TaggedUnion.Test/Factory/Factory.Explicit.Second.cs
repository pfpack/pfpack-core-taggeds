using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Second_Explicit_ExpectIsFirstGetsFalse()
    {
        var taggedUnion = TaggedUnion<StructType, RefType?>.Second(PlusFifteenIdRefType);
        ClassicAssert.False(taggedUnion.IsFirst);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Explicit_ExpectIsSecondGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<RefType?, object?>.Second(sourceValue);
        ClassicAssert.True(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Explicit_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<StructType, object?>.Second(sourceValue);
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Explicit_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<StructType, object?>.Second(sourceValue);
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
