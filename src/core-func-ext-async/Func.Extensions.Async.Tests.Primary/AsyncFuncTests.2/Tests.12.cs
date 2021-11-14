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
    public void From_12_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<string, int, decimal?, object?, RefType, StructType?, DateTime?, RecordType, int, StructType, object?, string?, Task<RefType?>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RecordRefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_12_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<int, object, RecordType?, RefType, object, string?, string, decimal, byte, RecordType, StructType, object, RecordType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            PlusFifteen, new { Name = UpperSomeString }, null, PlusFifteenIdRefType, null!, SomeString, EmptyString, decimal.MinusOne, byte.MaxValue, MinusFifteenIdSomeStringNameRecord, LowerSomeTextStructType, SomeTextStructType, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
