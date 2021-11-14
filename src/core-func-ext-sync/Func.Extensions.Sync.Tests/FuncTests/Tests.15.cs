using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_15_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<StructType, string, object?, decimal, RecordType, RefType, RecordType?, DateTimeOffset?, long, object, DateTime, RefType?, StructType, object, string, RefType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.StructType), MemberType = typeof(TestCaseSources))]
    public void From_15_ThenInvoke_ExpectResultOfSourceFunc(
        StructType sourceFuncResult)
    {
        var actual = Func.From<decimal, object, object?, decimal, RecordType?, object, long, int, RecordType, string, long, RefType?, StructType?, string, object, StructType>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            decimal.MinusOne, new(), null, decimal.MaxValue, PlusFifteenIdLowerSomeStringNameRecord, new { Sum = PlusFifteen }, long.MaxValue, MinusFifteen, MinusFifteenIdSomeStringNameRecord, SomeString, long.MinValue, null, null, WhiteSpaceString, SomeTextStructType);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
