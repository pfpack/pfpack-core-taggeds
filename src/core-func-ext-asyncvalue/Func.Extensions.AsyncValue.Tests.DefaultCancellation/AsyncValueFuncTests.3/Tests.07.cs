using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests3
{
    [Fact]
    public void From_07_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType, string, RefType?, object, Guid?, int, StructType, int>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RecordRefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_07_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<string?, int, RefType?, object, RecordType, string, StructType, RecordType?>(
            (_, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(
            SomeString, PlusFifteen, MinusFifteenIdRefType, SomeTextStructType, null!, EmptyString, LowerSomeTextStructType);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
