using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void ToString_SourceIsSuccessAndValueIsNull(
        Result<RefType, StructType> source)
    {
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Success:{2}",
            typeof(RefType).Name,
            typeof(StructType).Name,
            string.Empty);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToString_SourceIsSuccessAndValueToStringReturnsNull()
    {
        var sourceValue = new StubToStringRefType(null);
        var source = new Result<StubToStringRefType, StructType>(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Success:{2}",
            typeof(StubToStringRefType).Name,
            typeof(StructType).Name,
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
    public void ToString_SourceIsSuccess_ValueToString_Common(
        string? resultOfValueToString)
    {
        var sourceValue = new StubToStringStructType(resultOfValueToString);
        var source = Result<StubToStringStructType, SomeError>.Success(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Success:{2}",
            typeof(StubToStringStructType).Name,
            typeof(SomeError).Name,
            resultOfValueToString);

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
    public void ToString_SourceIsSuccess_Common(
        object? sourceSuccess)
    {
        var source = new Result<object?, StructType>(sourceSuccess);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Success:{2}",
            typeof(object).Name,
            typeof(StructType).Name,
            sourceSuccess);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ToString_SourceIsSuccess_DecimalPoint_TestCaseSource))]
    public void ToString_SourceIsSuccess_DecimalPoint(
        decimal sourceSuccess, string expectedDecimalSubstr)
    {
        var source = new Result<decimal, StructType>(sourceSuccess);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Success:{2}",
            typeof(decimal).Name,
            typeof(StructType).Name,
            expectedDecimalSubstr);

        Assert.That(actual, Is.EqualTo(expected));
    }

    private static IEnumerable<object[]> ToString_SourceIsSuccess_DecimalPoint_TestCaseSource()
    {
        yield return new object[] { -1.1m, "-1.1" };
        yield return new object[] { 0.0m, "0.0" };
        yield return new object[] { 1.1m, "1.1" };
    }
}
