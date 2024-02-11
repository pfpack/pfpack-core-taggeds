using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_ExpectIsFirstGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<object?, StructType> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsFirst);
    }

    [Test]
    public void First_Implicit_ExpectIsSecondGetsFalse()
    {
        TaggedUnion<StructType, RefType> taggedUnion = SomeTextStructType;
        ClassicAssert.False(taggedUnion.IsSecond);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_ExpectIsNoneGetsFalse(
        object? sourceValue)
    {
        TaggedUnion<object?, RefType> taggedUnion = sourceValue;
        ClassicAssert.False(taggedUnion.IsNone);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_ExpectIsNotNoneGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<object?, RefType> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsNotNone);
    }
}
