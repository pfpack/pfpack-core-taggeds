#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests3
{
    [Fact]
    public void From_10_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType?, object, string, DateTime?, int, StructType, long, RefType?, StructType?, RecordType, string>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(Zero)]
    [InlineData(MinusFifteen)]
    [InlineData(PlusFifteen)]
    [InlineData(int.MaxValue)]
    public async Task From_10_ThenInvokeAsync_ExpectResultOfSourceFunc(
        int? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<object?, StructType?, RefType?, RecordType?, int, string?, long, int?, RefType, StructType?, int?>(
            (_, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = new CancellationToken();

        var actualResult = await actual.InvokeAsync(
            null, SomeTextStructType, PlusFifteenIdRefType, MinusFifteenIdSomeStringNameRecord, MinusFifteen, TabString, long.MinValue, Zero, MinusFifteenIdRefType, LowerSomeTextStructType, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(Zero)]
    [InlineData(MinusFifteen)]
    [InlineData(PlusFifteen)]
    [InlineData(int.MaxValue)]
    public async Task From_10_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        int? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<object?, StructType?, RefType?, RecordType?, int, string?, long, int?, RefType, StructType?, int?>(
            (_, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                null, SomeTextStructType, PlusFifteenIdRefType, MinusFifteenIdSomeStringNameRecord, MinusFifteen, TabString, long.MinValue, Zero, MinusFifteenIdRefType, LowerSomeTextStructType, cancellationToken));
    }
}