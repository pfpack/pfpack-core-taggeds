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
    public void From_04_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, string, RecordType, StructType, Task<Guid>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_04_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult)
    {
        var actual = AsyncFunc.From<object, int, RecordType?, StructType, RefType?>(
            (_, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            new object(), MinusFifteen, PlusFifteenIdLowerSomeStringNameRecord, default);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
