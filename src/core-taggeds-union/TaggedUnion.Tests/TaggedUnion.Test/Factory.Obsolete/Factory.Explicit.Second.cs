using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Explicit_ExpectIsInitializedGetsTrue(
        object? sourceValue)
    {
        var taggedUnion = TaggedUnion<StructType, object?>.Second(sourceValue);
        ClassicAssert.True(taggedUnion.IsInitialized);
    }
}
