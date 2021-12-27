using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void ToString_SourceIsFirstAndValueIsNull()
    {
        var source = TaggedUnion<object?, StructType>.First(null);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}].First:{2}",
            typeof(object),
            typeof(StructType),
            string.Empty);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToString_SourceIsFirstAndValueToStringReturnsNull()
    {
        var sourceValue = new StubToStringType(null);
        var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}].First:{2}",
            typeof(StubToStringType),
            typeof(RefType),
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
    public void ToString_SourceIsFirst_ValueToString_Common(
        string resultOfValueToString)
    {
        var sourceValue = new StubToStringType(resultOfValueToString);
        var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion[{0},{1}].First:{2}",
            typeof(StubToStringType),
            typeof(RefType),
            resultOfValueToString);

        Assert.AreEqual(expected, actual);
    }
}
