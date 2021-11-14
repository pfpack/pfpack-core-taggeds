using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests
{
    [Fact]
    public void From_10_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType?, object, string, DateTime?, int, StructType, long, RefType?, StructType?, RecordType, CancellationToken, ValueTask<string>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.Int32Nullable), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_10_ThenInvokeAsync_ExpectResultOfSourceFunc(
        int? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<object?, StructType?, RefType?, RecordType?, int, string?, long, int?, RefType, StructType?, int?>(
            (_, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            null, SomeTextStructType, PlusFifteenIdRefType, MinusFifteenIdSomeStringNameRecord, MinusFifteen, TabString, long.MinValue, Zero, MinusFifteenIdRefType, LowerSomeTextStructType);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
