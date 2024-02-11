using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Second_Implicit_ExpectIsInitializedGetsTrue(
        object? sourceValue)
    {
        TaggedUnion<StructType, object?> taggedUnion = sourceValue;
        ClassicAssert.True(taggedUnion.IsInitialized);
    }
}
