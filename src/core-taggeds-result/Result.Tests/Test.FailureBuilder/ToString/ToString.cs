using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureBuilderTest
{
    [Test]
    public void ToString_SourceFailureToStringReturnsNull()
    {
        var sourceFailure = new StubToStringStructType(null);
        var builder = Result.Failure(sourceFailure);
        var actual = builder.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "FailureBuilder<{0}>:{1}",
            typeof(StubToStringStructType).Name,
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
    public void ToString_ValueToString_Common(
        string? resultOfFailureToString)
    {
        var sourceFailure = new StubToStringStructType(resultOfFailureToString);
        var builder = Result.Failure(sourceFailure);
        var actual = builder.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "FailureBuilder<{0}>:{1}",
            typeof(StubToStringStructType).Name,
            resultOfFailureToString);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(MinusOne)]
    [TestCase(Zero)]
    [TestCase(One)]
    public void ToString_Common(
        int sourceFailure)
    {
        var source = Result.Failure(sourceFailure);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "FailureBuilder<{0}>:{1}",
            typeof(int).Name,
            sourceFailure);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ToString_DecimalPoint_TestCaseSource))]
    public void ToString_DecimalPoint(
        decimal sourceFailure, string expectedDecimalSubstr)
    {
        var source = Result.Failure(sourceFailure);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "FailureBuilder<{0}>:{1}",
            typeof(decimal).Name,
            expectedDecimalSubstr);

        Assert.That(actual, Is.EqualTo(expected));
    }

    private static IEnumerable<object[]> ToString_DecimalPoint_TestCaseSource()
    {
        yield return new object[] { -1.1m, "-1.1" };
        yield return new object[] { 0.0m, "0.0" };
        yield return new object[] { 1.1m, "1.1" };
    }
}
