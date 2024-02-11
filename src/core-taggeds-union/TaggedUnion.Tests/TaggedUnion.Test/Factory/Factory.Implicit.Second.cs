using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Second_Implicit_ExpectIsFirstGetsFalse()
    {
        TaggedUnion<StructType, RefType?> taggedUnion = PlusFifteenIdRefType;
        ClassicAssert.False(taggedUnion.IsFirst);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_ExpectIsSecondGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<RefType?, object?> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        TaggedUnion<StructType, object?> taggedUnion = sourceValue;
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<StructType, object?> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
