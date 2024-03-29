using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class SuccessBuilderTest
{
    [Test]
    public void ToString_SourceSuccessIsNull()
    {
        var builder = Result.Success<RefType?>(null);
        var actual = builder.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "SuccessBuilder<{0}>:{1}",
            typeof(RefType).Name,
            string.Empty);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToString_SourceSuccessToStringReturnsNull()
    {
        var sourceSuccess = new StubToStringRefType(null);
        var builder = Result.Success(sourceSuccess);
        var actual = builder.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "SuccessBuilder<{0}>:{1}",
            typeof(StubToStringRefType).Name,
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
    public void ToString_SourceSuccess_ValueToString_Common(
        string? resultOfSuccessToString)
    {
        var sourceSuccess = new StubToStringRefType(resultOfSuccessToString);
        var builder = Result.Success(sourceSuccess);
        var actual = builder.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "SuccessBuilder<{0}>:{1}",
            typeof(StubToStringRefType).Name,
            resultOfSuccessToString);

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
    public void ToString_Common(
        object? sourceSuccess)
    {
        var source = Result.Success(sourceSuccess);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "SuccessBuilder<{0}>:{1}",
            typeof(object).Name,
            sourceSuccess);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ToString_DecimalPoint_TestCaseSource))]
    public void ToString_DecimalPoint(
        decimal sourceSuccess, string expectedDecimalSubstr)
    {
        var source = Result.Success(sourceSuccess);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "SuccessBuilder<{0}>:{1}",
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
