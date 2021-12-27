using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void DefaultConstructor_ExpectIsFirstGetsFalse()
    {
        var taggedUnion = new TaggedUnion<RefType?, StructType>();
        Assert.False(taggedUnion.IsFirst);
    }

    [Test]
    public void DefaultConstructor_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = new TaggedUnion<StructType?, RefType>();
        Assert.False(taggedUnion.IsSecond);
    }

    [Test]
    public void DefaultConstructor_ExpectIsNoneGetsTrue()
    {
        var taggedUnion = new TaggedUnion<RefType?, StructType?>();
        Assert.True(taggedUnion.IsNone);
    }
}
