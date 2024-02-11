using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void Default_ExpectIsFirstGetsFalse()
    {
        var taggedUnion = default(TaggedUnion<RefType?, StructType>);
        ClassicAssert.False(taggedUnion.IsFirst);
    }

    [Test]
    public void Default_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = default(TaggedUnion<StructType?, RefType>);
        ClassicAssert.False(taggedUnion.IsSecond);
    }

    [Test]
    public void Default_ExpectIsNoneGetsTrue()
    {
        var taggedUnion = default(TaggedUnion<RefType?, StructType?>);
        ClassicAssert.True(taggedUnion.IsNone);
    }

    [Test]
    public void Default_ExpectIsNotNoneGetsFalse()
    {
        var taggedUnion = default(TaggedUnion<RefType?, StructType?>);
        ClassicAssert.False(taggedUnion.IsNotNone);
    }
}
