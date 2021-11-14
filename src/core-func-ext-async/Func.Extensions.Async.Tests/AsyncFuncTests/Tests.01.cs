using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests
{
    [Fact]
    public void From_01_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<StructType?, CancellationToken, Task<RefType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.RecordRefType), MemberType = typeof(TestCaseSources))]
    public async Task From_01_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<RefType, RecordType?>((_, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(PlusFifteenIdRefType, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
