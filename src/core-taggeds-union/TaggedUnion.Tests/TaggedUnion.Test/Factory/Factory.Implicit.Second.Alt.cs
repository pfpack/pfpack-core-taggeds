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
        ClassicAssert.False(taggedUnion.IsFirst);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_Alt_ExpectIsSecondGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<StructType, object?> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_Alt_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        TaggedUnion<RefType, object?> taggedUnion = sourceValue;
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_Alt_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<RefType, object?> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
