#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.Core.Tests.AssertHelper;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Fact]
    public void CreateUnitFailureCode_SourceFailureMessageIsNull_ExpectFailureCodeIsUnitAndMessageIsEmpty()
    {
        var actual = Failure.Create(null);

        AssertEqualFailures(
            (Unit.Value, EmptyString),
            (actual.FailureCode, actual.FailureMessage));
    }

    [Theory]
    [InlineData(EmptyString)]
    [InlineData(WhiteSpaceString)]
    [InlineData(TabString)]
    [InlineData(LowerSomeString)]
    [InlineData(SomeString)]
    public void CreateUnitFailureCode_SourceFailureMessageIsNotNull_ExpectFailureCodeIsUnitAndMessageIsEqualToSource(
        string sourceFailureMessage)
    {
        var actual = Failure.Create(sourceFailureMessage);

        AssertEqualFailures(
            (Unit.Value, sourceFailureMessage),
            (actual.FailureCode, actual.FailureMessage));
    }
}
