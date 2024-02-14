using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void ToString_SourceIsAbsent()
    {
        var source = Optional<StubType>.Absent;

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Optional<{0}>:Absent:()",
            typeof(StubType).Name);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToString_SourceIsPresentAndValueIsNull()
    {
        var source = Optional<StubType?>.Present(null);

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Optional<{0}>:Present:{1}",
            typeof(StubType).Name,
            string.Empty);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToString_SourceIsPresentAndValueToStringIsNull()
    {
        var sourceValue = new StubType(null);
        var source = Optional<StubType>.Present(sourceValue);

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Optional<{0}>:Present:{1}",
            typeof(StubType).Name,
            string.Empty);

        Assert.That(actual, Is.EqualTo(expected));
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
    public void ToString_SourceIsPresent_ValueToString_Common(
        string? sourceValueToStringResult)
    {
        var sourceValue = new StubType(sourceValueToStringResult);
        var source = Optional<StubType>.Present(sourceValue);

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Optional<{0}>:Present:{1}",
            typeof(StubType).Name,
            sourceValueToStringResult);

        Assert.That(actual, Is.EqualTo(expected));
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
    public void ToString_SourceIsPresent_Common(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Optional<{0}>:Present:{1}",
            typeof(object).Name,
            sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ToString_SourceIsPresent_DecimalPoint_TestCaseSource))]
    public void ToString_SourceIsPresent_DecimalPoint(
        decimal sourceValue, string expectedDecimalSubstr)
    {
        var source = Optional<decimal>.Present(sourceValue);

        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Optional<{0}>:Present:{1}",
            typeof(decimal).Name,
            expectedDecimalSubstr);

        Assert.That(actual, Is.EqualTo(expected));
    }

    private static IEnumerable<object[]> ToString_SourceIsPresent_DecimalPoint_TestCaseSource()
    {
        yield return new object[] { -1.1m, "-1.1" };
        yield return new object[] { 0.0m, "0.0" };
        yield return new object[] { 1.1m, "1.1" };
    }
}
