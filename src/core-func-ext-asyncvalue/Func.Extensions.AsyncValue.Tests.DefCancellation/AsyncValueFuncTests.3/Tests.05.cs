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
    public void From_05_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, object, Guid, StructType, RecordType, string?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.StructType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_05_ThenInvokeAsync_ExpectResultOfSourceFunc(
        StructType sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<int?, RecordType, RefType?, string, object, StructType>(
            (_, _, _, _, _) => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(
            MinusFifteen, PlusFifteenIdSomeStringNameRecord, null, SomeString, new());

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
