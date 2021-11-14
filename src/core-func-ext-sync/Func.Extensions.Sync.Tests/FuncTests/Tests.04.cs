using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_04_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RecordType, Guid, StructType, string, RefType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.String), MemberType = typeof(TestCaseSources))]
    public void From_04_ThenInvoke_ExpectResultOfSourceFunc(
        string sourceFuncResult)
    {
        var actual = Func.From<int?, RefType, StructType, RecordType?, string>(
            (_, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            null, MinusFifteenIdRefType, LowerSomeTextStructType, ZeroIdNullNameRecord);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
