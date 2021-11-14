using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests2
{
    [Fact]
    public void From_05_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, object, Guid, StructType, RecordType, ValueTask<string?>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.StructType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_05_ThenInvokeAsync_ExpectResultOfSourceFunc(
        StructType sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncValueFunc.From<int?, RecordType, RefType?, string, object, StructType>(
            (_, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            MinusFifteen, PlusFifteenIdSomeStringNameRecord, null, SomeString, new(), sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
