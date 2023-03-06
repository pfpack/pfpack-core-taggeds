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
    public void ToString_SourceIsFirstAndValueIsNull()
    {
        var source = TaggedUnion<object?, StructType>.First(null);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:First:{2}",
            typeof(object).Name,
            typeof(StructType).Name,
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
            "TaggedUnion<{0}, {1}>:First:{2}",
            typeof(StubToStringType).Name,
            typeof(RefType).Name,
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
        string? resultOfValueToString)
    {
        var sourceValue = new StubToStringType(resultOfValueToString);
        var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:First:{2}",
            typeof(StubToStringType).Name,
            typeof(RefType).Name,
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
    public void ToString_SourceIsFirst_Common(
        object? sourceValue)
    {
        var source = TaggedUnion<object?, RefType>.First(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:First:{2}",
            typeof(object).Name,
            typeof(RefType).Name,
            sourceValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(ToString_SourceIsFirst_DecimalPoint_TestCaseSource))]
    public void ToString_SourceIsFirst_DecimalPoint(
        decimal sourceValue, string expectedDecimalSubstr)
    {
        var source = TaggedUnion<object?, RefType>.First(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "TaggedUnion<{0}, {1}>:First:{2}",
            typeof(object).Name,
            typeof(RefType).Name,
            expectedDecimalSubstr);

        Assert.AreEqual(expected, actual);
    }

    private static IEnumerable<object[]> ToString_SourceIsFirst_DecimalPoint_TestCaseSource()
    {
        yield return new object[] { -1.1m, "-1.1" };
        yield return new object[] { 0.0m, "0.0" };
        yield return new object[] { 1.1m, "1.1" };
    }
}
