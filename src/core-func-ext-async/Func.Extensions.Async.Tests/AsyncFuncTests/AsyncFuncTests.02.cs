#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests
{
    [Fact]
    public void From_02_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, RecordType, CancellationToken, Task<StructType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(true)]
    [InlineData(false)]
    public async Task From_02_ThenInvokeAsync_ExpectResultOfSourceFunc(
        bool? sourceFuncResult)
    {
        var actual = AsyncFunc.From<RecordType?, StructType, bool?>(
            (_, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = default(CancellationToken);
        var actualResult = await actual.InvokeAsync(MinusFifteenIdNullNameRecord, default, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(true)]
    [InlineData(false)]
    public async Task From_02_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        bool? sourceFuncResult)
    {
        var actual = AsyncFunc.From<RecordType?, StructType, bool?>(
            (_, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = new CancellationToken(canceled: true);
            _ = await Assert.ThrowsAsync<TaskCanceledException>(
                async () => await actual.InvokeAsync(MinusFifteenIdNullNameRecord, default, cancellationToken));
    }
}
