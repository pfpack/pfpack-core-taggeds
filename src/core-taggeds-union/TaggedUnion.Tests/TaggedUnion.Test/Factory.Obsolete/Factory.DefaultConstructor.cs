using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Obsolete]
    [Test]
    public void DefaultConstructor_ExpectIsInitializedGetsFalse()
    {
        var taggedUnion = new TaggedUnion<RefType?, StructType?>();
        Assert.False(taggedUnion.IsInitialized);
    }
}
