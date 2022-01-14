using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ToString_SourceIsFailureAndValueToStringReturnsNull_ExpectEmptyString()
    {
        var sourceValue = new StubToStringStructType(null);
        var source = Result<RefType?, StubToStringStructType>.Failure(sourceValue);

        var actual = source.ToString();
        Assert.IsEmpty(actual);
    }

    [Test]
    [TestCase(EmptyString)]
    [TestCase(WhiteSpaceString)]
    [TestCase(TabString)]
    [TestCase(SomeString)]
    public void ToString_SourceIsFailureAndValueToStringDoesNotReturnNull_ExpectResultOfValueToString(
        string resultOfValueToString)
    {
        var sourceValue = new StubToStringStructType(resultOfValueToString);
        var source = new Result<StructType, StubToStringStructType>(sourceValue);

        var actual = source.ToString();
        Assert.AreEqual(resultOfValueToString, actual);
    }
}
