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
    public void From_00_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<StructType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(WhiteSpaceString)]
    [InlineData(SomeString)]
    public async Task From_00_ThenInvokeAsync_ExpectResultOfSourceFunc(
        string? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From(() => sourceFuncResult);

        var cancellationToken = default(CancellationToken);
        var actualResult = await actual.InvokeAsync(cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(WhiteSpaceString)]
    [InlineData(SomeString)]
    public async Task From_00_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        string? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From(() => sourceFuncResult);

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(cancellationToken));
    }
}
