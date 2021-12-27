using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void ToString_SourceIsNone()
    {
        var source = default(TaggedUnion<StructType, RefType>);
        var actual = source.ToString();

        Assert.IsEmpty(actual);
    }
}
