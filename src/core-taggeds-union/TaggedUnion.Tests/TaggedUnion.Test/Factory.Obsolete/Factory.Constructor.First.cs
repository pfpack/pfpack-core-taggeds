using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Constructor_ExpectIsInitializedGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<object?, RefType>(sourceValue);
        ClassicAssert.True(taggedUnion.IsInitialized);
    }
}
