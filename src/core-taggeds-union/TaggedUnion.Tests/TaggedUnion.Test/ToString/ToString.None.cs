using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Globalization;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void ToString_SourceIsNone()
    {
        var source = default(TaggedUnion<StructType, RefType>);

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}]:None:()",
            typeof(StructType),
            typeof(RefType));

        Assert.AreEqual(expected, actual);
    }
}
