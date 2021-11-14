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
    public void From_11_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType?, string, StructType, long?, object, DateTimeKind, RefType?, decimal, object, RecordType, byte, CancellationToken, Task<DateTime>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.RefType), MemberType = typeof(TestCaseSources))]
    public async Task From_11_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<StructType, RefType?, long, string, RefType, object, long, DateTimeKind, RefType, object, StructType?, RefType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            LowerSomeTextStructType, default, long.MaxValue, UpperSomeString, PlusFifteenIdRefType, null!, long.MinValue, DateTimeKind.Utc, null!, MinusFifteenIdRefType, SomeTextStructType, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
