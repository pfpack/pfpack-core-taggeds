using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
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
            "TaggedUnion<{0}, {1}>:Second:{2}",
            typeof(decimal).Name,
            typeof(StructType?).Name,
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
            "TaggedUnion<{0}, {1}>:Second:{2}",
            typeof(string).Name,
            typeof(StubToStringType).Name,
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
        string? resultOfValueToString)
    {
        var sourceValue = new StubToStringType(resultOfValueToString);
        var source = TaggedUnion<StructType, StubToStringType>.Second(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:Second:{2}",
            typeof(StructType).Name,
            typeof(StubToStringType).Name,
            resultOfValueToString);

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
    [TestCase(MinusOne)]
    [TestCase(Zero)]
    [TestCase(One)]
    public void ToString_SourceIsSecond_Common(
        object? sourceValue)
    {
        var source = TaggedUnion<StructType, object?>.Second(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:Second:{2}",
            typeof(StructType).Name,
            typeof(object).Name,
            sourceValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(ToString_SourceIsSecond_DecimalPoint_TestCaseSource))]
    public void ToString_SourceIsSecond_DecimalPoint(
        object? sourceValue, string expectedDecimalSubstr)
    {
        var source = TaggedUnion<StructType, object?>.Second(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:Second:{2}",
            typeof(StructType).Name,
            typeof(object).Name,
            expectedDecimalSubstr);

        Assert.AreEqual(expected, actual);
    }

    private static IEnumerable<object[]> ToString_SourceIsSecond_DecimalPoint_TestCaseSource()
    {
        yield return new object[] { -1.1m, "-1.1" };
        yield return new object[] { 0.0m, "0.0" };
        yield return new object[] { 1.1m, "1.1" };
    }
}
