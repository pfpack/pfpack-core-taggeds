using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void First_Implicit_ExpectIsInitializedGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<object?, RefType> taggedUnion = sourceValue;
        Assert.True(taggedUnion.IsInitialized);
    }
}
