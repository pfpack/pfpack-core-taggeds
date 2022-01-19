using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_ExpectIsInitializedGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = new TaggedUnion<StructType, object?>(sourceValue);
        Assert.True(taggedUnion.IsInitialized);
    }
}
