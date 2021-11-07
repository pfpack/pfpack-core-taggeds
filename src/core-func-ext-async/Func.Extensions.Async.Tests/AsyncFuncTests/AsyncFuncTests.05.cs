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
    public void From_05_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, object, Guid, StructType, RecordType, CancellationToken, Task<string?>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_05_ThenInvokeAsync_ExpectResultOfSourceFunc(
        StructType sourceFuncResult)
    {
        var actual = AsyncFunc.From<int?, RecordType, RefType?, string, object, StructType>(
            (_, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = default(CancellationToken);

        var actualResult = await actual.InvokeAsync(
            MinusFifteen, PlusFifteenIdSomeStringNameRecord, null, SomeString, new(), cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public async Task From_05_Canceled_ThenInvokeAsync_ExpectTaskCanceledException(
        StructType sourceFuncResult)
    {
        var actual = AsyncFunc.From<int?, RecordType, RefType?, string, object, StructType>(
            (_, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var cancellationToken = new CancellationToken(canceled: true);

        _ = await Assert.ThrowsAsync<TaskCanceledException>(
            async () => await actual.InvokeAsync(
                MinusFifteen, PlusFifteenIdSomeStringNameRecord, null, SomeString, new(), cancellationToken));
    }
}
