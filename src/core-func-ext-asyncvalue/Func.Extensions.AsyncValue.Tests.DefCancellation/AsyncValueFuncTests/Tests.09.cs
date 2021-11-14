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
    public void From_09_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<long, RefType?, StructType, RecordType, DateTimeOffset, int?, RecordType?, object?, RefType, CancellationToken, ValueTask<object?>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.StructType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_09_ThenInvokeAsync_ExpectResultOfSourceFunc(
        StructType sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<RecordType, RefType, int, object?, StructType, string, RecordType?, string?, RefType?, StructType>(
            (_, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            ZeroIdNullNameRecord, MinusFifteenIdRefType, MinusFifteen, new(), default, SomeString, null, WhiteSpaceString, MinusFifteenIdRefType);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
