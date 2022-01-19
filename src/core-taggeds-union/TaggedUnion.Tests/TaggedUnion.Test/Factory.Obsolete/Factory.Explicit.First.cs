using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Explicit_ExpectIsInitializedGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<object?, RefType>.First(sourceValue);
        Assert.True(taggedUnion.IsInitialized);
    }
}
