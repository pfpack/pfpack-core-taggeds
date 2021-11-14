using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests2
{
    [Fact]
    public void From_10_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType?, object, string, DateTime?, int, StructType, long, RefType?, StructType?, RecordType, Task<string>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.Int32Nullable), MemberType = typeof(TestCaseSources))]
    public async Task From_10_ThenInvokeAsync_ExpectResultOfSourceFunc(
        int? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<object?, StructType?, RefType?, RecordType?, int, string?, long, int?, RefType, StructType?, int?>(
            (_, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            null, SomeTextStructType, PlusFifteenIdRefType, MinusFifteenIdSomeStringNameRecord, MinusFifteen, TabString, long.MinValue, Zero, MinusFifteenIdRefType, LowerSomeTextStructType, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
