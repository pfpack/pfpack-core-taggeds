using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedsExtensionsTests
{
    [Test]
    [TestCase(null)]
    [TestCase(EmptyString)]
    [TestCase(WhiteSpaceString)]
    [TestCase(TabString)]
    [TestCase(SomeString)]
    public void Optional_ToResult_SourceOptionalIsPresent_ExpectSuccessResultOfSourceValue(
        string? sourceValue)
    {
        var sourceOptional = Optional<string?>.Present(sourceValue);

        var actual = sourceOptional.ToResult();
        var expected = Result<string?, Unit>.Success(sourceValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Optional_ToResult_SourceOptionalIsAbsent_ExpectFailureResultOfUnit()
    {
        var sourceOptional = Optional<SomeRecord>.Absent;

        var actual = sourceOptional.ToResult();
        var expected = Result<SomeRecord, Unit>.Failure(Unit.Value);

        Assert.AreEqual(expected, actual);
    }
}
