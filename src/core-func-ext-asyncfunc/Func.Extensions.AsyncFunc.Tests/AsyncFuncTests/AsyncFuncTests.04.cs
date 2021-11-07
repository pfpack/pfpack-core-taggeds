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
    public void From_04_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, string, RecordType, StructType, CancellationToken, Task<Guid>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_04_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<object, int, RecordType?, StructType, RefType?>(
            (_, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = default(CancellationToken);

        var actualResult = await actual.InvokeAsync(
            new object(), MinusFifteen, PlusFifteenIdLowerSomeStringNameRecord, default, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_04_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        RefType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<object, int, RecordType?, StructType, RefType?>(
            (_, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                new object(), MinusFifteen, PlusFifteenIdLowerSomeStringNameRecord, default, cancellationToken));
    }
}
