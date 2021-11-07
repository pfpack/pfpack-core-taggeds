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
    public void From_06_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, StructType, string, RecordType?, DateTimeKind, object, RecordType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(WhiteSpaceString)]
    [InlineData(TabString)]
    [InlineData(LowerSomeString)]
    [InlineData(SomeString)]
    public async Task From_06_ThenInvokeAsync_ExpectResultOfSourceFunc(
        string? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<RefType, string, StructType?, object, RecordType, int, string?>(
            (_, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = default(CancellationToken);

        var actualResult = await actual.InvokeAsync(
            MinusFifteenIdRefType, null!, new(), new(), PlusFifteenIdLowerSomeStringNameRecord, int.MaxValue, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(WhiteSpaceString)]
    [InlineData(TabString)]
    [InlineData(LowerSomeString)]
    [InlineData(SomeString)]
    public async Task From_06_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        string? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<RefType, string, StructType?, object, RecordType, int, string?>(
            (_, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                MinusFifteenIdRefType, null!, new(), new(), PlusFifteenIdLowerSomeStringNameRecord, int.MaxValue, cancellationToken));
    }
}
