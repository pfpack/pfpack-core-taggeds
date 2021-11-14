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
    public void From_13_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<long, RecordType, string?, object?, RecordType?, object?, RecordType, DateTimeOffset, object, DateTimeKind, string, int, RecordType?, CancellationToken, ValueTask<long>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_13_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncValueFunc.From<decimal, StructType, RefType?, RecordType?, long, int, RefType, DateTimeKind, RefType, object?, string, RecordType, string?, RefType>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            decimal.One, SomeTextStructType, PlusFifteenIdRefType, ZeroIdNullNameRecord, default, default, MinusFifteenIdRefType, DateTimeKind.Unspecified, null!, new(), ThreeWhiteSpacesString, MinusFifteenIdNullNameRecord, EmptyString, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
