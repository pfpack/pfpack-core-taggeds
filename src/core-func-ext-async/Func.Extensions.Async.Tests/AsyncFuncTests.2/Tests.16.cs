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
    public void From_16_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType, int?, string, RefType?, StructType, DateTimeKind?, DateTime, int, byte, string, RecordType?, object, decimal, long, StructType?, DateTimeOffset, Task<RecordType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.RefType), MemberType = typeof(TestCaseSources))]
    public async Task From_16_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<StructType?, string, long, object?, int, RefType, RecordType, decimal, string?, byte, object, RefType?, object?, decimal?, byte?, DateTimeOffset, RefType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            LowerSomeTextStructType, SomeString, long.MaxValue, null, MinusFifteen, PlusFifteenIdRefType, PlusFifteenIdLowerSomeStringNameRecord, decimal.One, ThreeWhiteSpacesString, byte.MaxValue, new { Name = SomeString }, ZeroIdRefType, new(), decimal.MaxValue, null, DateTimeOffset.MinValue, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
