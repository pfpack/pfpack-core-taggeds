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
        ClassicAssert.False(taggedUnion.IsFirst);
    }

    [Test]
    public void DefaultConstructor_ExpectIsSecondGetsFalse()
    {
        var taggedUnion = new TaggedUnion<StructType?, RefType>();
        ClassicAssert.False(taggedUnion.IsSecond);
    }

    [Test]
    public void DefaultConstructor_ExpectIsNoneGetsTrue()
    {
        var taggedUnion = new TaggedUnion<RefType?, StructType?>();
        ClassicAssert.True(taggedUnion.IsNone);
    }

    [Test]
    public void DefaultConstructor_ExpectIsNotNoneGetsFalse()
    {
        var taggedUnion = new TaggedUnion<RefType?, StructType?>();
        ClassicAssert.False(taggedUnion.IsNotNone);
    }
}
