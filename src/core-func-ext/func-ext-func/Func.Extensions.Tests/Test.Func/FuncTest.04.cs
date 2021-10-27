#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTest
{
    [Fact]
    public void From_04_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType, Guid, StructType, string, RefType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(WhiteSpaceString)]
    [InlineData(TabString)]
    [InlineData(LowerSomeString)]
    [InlineData(SomeString)]
    public void From_04_ThenInvoke_ExpectResultOfSourceFunc(
        string sourceFuncResult)
    {
        var actual = Func.From<int?, RefType, StructType, RecordType?, string>(
            (_, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            null, MinusFifteenIdRefType, LowerSomeTextStructType, ZeroIdNullNameRecord);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
