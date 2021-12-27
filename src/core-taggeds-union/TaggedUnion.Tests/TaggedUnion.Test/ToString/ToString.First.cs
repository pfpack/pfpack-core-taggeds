using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void ToString_SourceIsFirstAndValueIsNull()
    {
        var source = TaggedUnion<object?, StructType>.First(null);
        var actual = source.ToString();

        Assert.IsEmpty(actual);
    }

    [Test]
    public void ToString_SourceIsFirstAndValueToStringReturnsNull()
    {
        var sourceValue = new StubToStringType(null);

        var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
        var actual = source.ToString();

        Assert.IsEmpty(actual);
    }

    [Test]
    [TestCase(EmptyString)]
    [TestCase(WhiteSpaceString)]
    [TestCase(TabString)]
    [TestCase(SomeString)]
    public void ToString_SourceIsFirstAndValueToStringDoesNotReturnNull(
        string resultOfValueToString)
    {
        var sourceValue = new StubToStringType(resultOfValueToString);

        var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
        var actual = source.ToString();

        Assert.AreEqual(resultOfValueToString, actual);
    }
}
