#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTest
{
    [Fact]
    public void From_02_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, RecordType, CancellationToken, ValueTask<StructType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(true)]
    [InlineData(false)]
    public async ValueTask From_02_ThenInvokeAsync_ExpectResultOfSourceFunc(
        bool? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<RecordType?, StructType, bool?>(
            (_, _, _) => ValueTask.FromResult(sourceFuncResult));

        var cancellationToken = new CancellationToken(canceled: true);
        var actualResult = await actual.InvokeAsync(MinusFifteenIdNullNameRecord, default, cancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
