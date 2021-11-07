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
    public void From_15_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType, int?, string, RefType?, StructType, DateTimeKind?, DateTime, int, byte, string, RecordType?, object, decimal, long, StructType?, RecordType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_15_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<StructType?, string, long, object?, int, RefType, RecordType, decimal, string?, byte, object, RefType?, object?, decimal?, byte?, RefType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = new CancellationToken(canceled: false);

        var actualResult = await actual.InvokeAsync(
            LowerSomeTextStructType, SomeString, long.MaxValue, null, MinusFifteen, PlusFifteenIdRefType, PlusFifteenIdLowerSomeStringNameRecord, decimal.One, ThreeWhiteSpacesString, byte.MaxValue, new { Name = SomeString }, ZeroIdRefType, new(), decimal.MaxValue, null, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_15_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        RefType? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<StructType?, string, long, object?, int, RefType, RecordType, decimal, string?, byte, object, RefType?, object?, decimal?, byte?, RefType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                LowerSomeTextStructType, SomeString, long.MaxValue, null, MinusFifteen, PlusFifteenIdRefType, PlusFifteenIdLowerSomeStringNameRecord, decimal.One, ThreeWhiteSpacesString, byte.MaxValue, new { Name = SomeString }, ZeroIdRefType, new(), decimal.MaxValue, null, cancellationToken));
    }
}
