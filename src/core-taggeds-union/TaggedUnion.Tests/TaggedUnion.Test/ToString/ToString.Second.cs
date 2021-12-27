using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void ToString_SourceIsSecondAndValueIsNull()
    {
        var source = TaggedUnion<decimal, StructType?>.Second(null);
        var actual = source.ToString();

        Assert.IsEmpty(actual);
    }

    [Test]
    public void ToString_SourceIsSecondAndValueToStringReturnsNull()
    {
        var sourceValue = new StubToStringType(null);

        var source = TaggedUnion<string, StubToStringType>.Second(sourceValue);
        var actual = source.ToString();

        Assert.IsEmpty(actual);
    }

    [Test]
    [TestCase(EmptyString)]
    [TestCase(WhiteSpaceString)]
    [TestCase(TabString)]
    [TestCase(SomeString)]
    public void ToString_SourceIsSecondAndValueToStringDoesNotReturnNull(
        string resultOfValueToString)
    {
        var sourceValue = new StubToStringType(resultOfValueToString);

        var source = TaggedUnion<StructType, StubToStringType>.Second(sourceValue);
        var actual = source.ToString();

        Assert.AreEqual(resultOfValueToString, actual);
    }
}
