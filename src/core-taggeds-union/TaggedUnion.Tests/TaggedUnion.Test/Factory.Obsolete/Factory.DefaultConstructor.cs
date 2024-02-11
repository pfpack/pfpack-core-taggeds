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
        ClassicAssert.False(taggedUnion.IsInitialized);
    }
}
