using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests3
{
    [Fact]
    public void From_08_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<DateTimeOffset, object, RefType?, Guid, RecordType, StructType?, string, long, RecordType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_08_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<object, RefType?, DateTimeKind, RecordType, int, string, StructType, RecordType, RefType?>(
            (_, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(
            new { Id = PlusFifteen }, default, DateTimeKind.Local, PlusFifteenIdLowerSomeStringNameRecord, MinusFifteen, null!, SomeTextStructType, MinusFifteenIdSomeStringNameRecord, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
