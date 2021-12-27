using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void ToString_SourceIsSecondAndValueIsNull()
    {
        var source = TaggedUnion<decimal, StructType?>.Second(null);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}].Second:{2}",
            typeof(decimal),
            typeof(StructType?),
            string.Empty);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToString_SourceIsSecondAndValueToStringReturnsNull()
    {
        var sourceValue = new StubToStringType(null);
        var source = TaggedUnion<string, StubToStringType>.Second(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}].Second:{2}",
            typeof(string),
            typeof(StubToStringType),
            string.Empty);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(null)]
    [TestCase(EmptyString)]
    [TestCase(TabString)]
    [TestCase(TwoTabsString)]
    [TestCase(WhiteSpaceString)]
    [TestCase(TwoWhiteSpacesString)]
    [TestCase(ThreeWhiteSpacesString)]
    [TestCase(MixedWhiteSpacesString)]
    [TestCase(SomeString)]
    public void ToString_SourceIsSecond_ValueToString_Common(
        string resultOfValueToString)
    {
        var sourceValue = new StubToStringType(resultOfValueToString);
        var source = TaggedUnion<StructType, StubToStringType>.Second(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}].Second:{2}",
            typeof(StructType),
            typeof(StubToStringType),
            resultOfValueToString);

        Assert.AreEqual(expected, actual);
    }
}
