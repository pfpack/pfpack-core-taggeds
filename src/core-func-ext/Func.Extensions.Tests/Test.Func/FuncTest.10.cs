#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTest
{
    [Fact]
    public void From_10_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType, RecordType?, StructType?, long, string, int, RecordType, RefType, StructType, Guid?, RefType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(MinusFifteen)]
    [InlineData(Zero)]
    [InlineData(PlusFifteen)]
    [InlineData(int.MaxValue)]
    public void From_10_ThenInvoke_ExpectResultOfSourceFunc(
        int sourceFuncResult)
    {
        var actual = Func.From<decimal?, StructType, string?, RefType, StructType, object?, RefType?, RecordType, byte, DateTimeKind, int>(
            (_, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            null, default, LowerSomeString, PlusFifteenIdRefType, SomeTextStructType, new(), null, null!, byte.MaxValue, DateTimeKind.Unspecified);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
