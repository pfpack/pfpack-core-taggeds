using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests3
{
    [Fact]
    public void From_15_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType, int?, string, RefType?, StructType, DateTimeKind?, DateTime, int, byte, string, RecordType?, object, decimal, long, StructType?, RecordType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_15_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncValueFunc.From<StructType?, string, long, object?, int, RefType, RecordType, decimal, string?, byte, object, RefType?, object?, decimal?, byte?, RefType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(
            LowerSomeTextStructType, SomeString, long.MaxValue, null, MinusFifteen, PlusFifteenIdRefType, PlusFifteenIdLowerSomeStringNameRecord, decimal.One, ThreeWhiteSpacesString, byte.MaxValue, new { Name = SomeString }, ZeroIdRefType, new(), decimal.MaxValue, null, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}