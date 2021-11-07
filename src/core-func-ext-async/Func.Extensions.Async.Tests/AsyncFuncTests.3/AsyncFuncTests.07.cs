#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests3
{
    [Fact]
    public void From_07_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType, string, RefType?, object, Guid?, int, StructType, int>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_07_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<string?, int, RefType?, object, RecordType, string, StructType, RecordType?>(
            (_, _, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = CancellationToken.None;

        var actualResult = await actual.InvokeAsync(
            SomeString, PlusFifteen, MinusFifteenIdRefType, SomeTextStructType, null!, EmptyString, LowerSomeTextStructType, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_07_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        RecordType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<string?, int, RefType?, object, RecordType, string, StructType, RecordType?>(
            (_, _, _, _, _, _, _) => sourceFuncResult);

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                SomeString, PlusFifteen, MinusFifteenIdRefType, SomeTextStructType, null!, EmptyString, LowerSomeTextStructType, cancellationToken));
    }
}
