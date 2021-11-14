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
    public void From_02_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, RecordType, StructType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.BooleanNullable), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_02_ThenInvokeAsync_ExpectResultOfSourceFunc(
        bool? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<RecordType?, StructType, bool?>(
            (_, _) => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(MinusFifteenIdNullNameRecord, default);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
