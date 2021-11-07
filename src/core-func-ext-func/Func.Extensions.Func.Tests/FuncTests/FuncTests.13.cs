#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_13_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType, string, int, RefType, DateTime, StructType, StructType?, DateTimeKind, object?, RecordType?, RefType, int, object?, string>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void From_13_ThenInvoke_ExpectResultOfSourceFunc(
        RefType sourceFuncResult)
    {
        var actual = Func.From<RecordType, int, StructType, object, RefType, decimal, long?, RecordType?, string, long, StructType, long, RefType?, RefType>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            ZeroIdNullNameRecord, MinusFifteen, LowerSomeTextStructType, null!, null!, decimal.MinusOne, long.MaxValue, MinusFifteenIdNullNameRecord, EmptyString, long.MinValue, default, long.MinValue, PlusFifteenIdRefType);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
