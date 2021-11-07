#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests2
{
    [Fact]
    public void From_12_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<string, int, decimal?, object?, RefType, StructType?, DateTime?, RecordType, int, StructType, object?, string?, Task<RefType?>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_12_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<int, object, RecordType?, RefType, object, string?, string, decimal, byte, RecordType, StructType, object, RecordType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = new CancellationToken();

        var actualResult = await actual.InvokeAsync(
            PlusFifteen, new { Name = UpperSomeString }, null, PlusFifteenIdRefType, null!, SomeString, EmptyString, decimal.MinusOne, byte.MaxValue, MinusFifteenIdSomeStringNameRecord, LowerSomeTextStructType, SomeTextStructType, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_12_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        RecordType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<int, object, RecordType?, RefType, object, string?, string, decimal, byte, RecordType, StructType, object, RecordType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                PlusFifteen, new { Name = UpperSomeString }, null, PlusFifteenIdRefType, null!, SomeString, EmptyString, decimal.MinusOne, byte.MaxValue, MinusFifteenIdSomeStringNameRecord, LowerSomeTextStructType, SomeTextStructType, cancellationToken));
    }
}