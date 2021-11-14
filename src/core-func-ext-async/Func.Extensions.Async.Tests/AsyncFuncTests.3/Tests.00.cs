using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests3
{
    [Fact]
    public void From_00_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<StructType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.String), MemberType = typeof(TestCaseSources))]
    public async Task From_00_ThenInvokeAsync_ExpectResultOfSourceFunc(
        string? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From(() => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
