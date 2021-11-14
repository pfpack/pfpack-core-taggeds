using PrimeFuncPack.UnitTest;
using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_00_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<StructType>)null!;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.RefType), MemberType = typeof(TestCaseSources))]
    public void From_00_ThenInvoke_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult)
    {
        var actual = Func.From(
            () => sourceFuncResult);

        var actualResult = actual.Invoke();
        Assert.Equal(sourceFuncResult, actualResult);
    }
}
