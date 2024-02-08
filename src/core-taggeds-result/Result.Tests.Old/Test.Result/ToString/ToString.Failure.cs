using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ToString_SourceIsFailureAndValueToStringReturnsNull()
    {
        var sourceValue = new StubToStringStructType(null);
        var source = Result<RefType?, StubToStringStructType>.Failure(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Failure:{2}",
            typeof(RefType).Name,
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
    public void ToString_SourceIsFailure_ValueToString_Common(
        string? resultOfValueToString)
    {
        var sourceValue = new StubToStringStructType(resultOfValueToString);
        var source = new Result<StructType, StubToStringStructType>(sourceValue);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Failure:{2}",
            typeof(StructType).Name,
            typeof(StubToStringStructType).Name,
            resultOfValueToString);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(MinusOne)]
    [TestCase(Zero)]
    [TestCase(One)]
    public void ToString_SourceIsFailure_Common(
        int sourceFailure)
    {
        var source = new Result<StructType, int>(sourceFailure);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Failure:{2}",
            typeof(StructType).Name,
            typeof(int).Name,
            sourceFailure);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ToString_SourceIsFailure_DecimalPoint_TestCaseSource))]
    public void ToString_SourceIsFailure_DecimalPoint(
        decimal sourceFailure, string expectedDecimalSubstr)
    {
        var source = new Result<object, decimal>(sourceFailure);
        var actual = source.ToString();

        var expected = string.Format(
            CultureInfo.InvariantCulture,
            "Result<{0}, {1}>:Failure:{2}",
            typeof(object).Name,
            typeof(decimal).Name,
            expectedDecimalSubstr);

        Assert.That(actual, Is.EqualTo(expected));
    }

    private static IEnumerable<object[]> ToString_SourceIsFailure_DecimalPoint_TestCaseSource()
    {
        yield return new object[] { -1.1m, "-1.1" };
        yield return new object[] { 0.0m, "0.0" };
        yield return new object[] { 1.1m, "1.1" };
    }
}
