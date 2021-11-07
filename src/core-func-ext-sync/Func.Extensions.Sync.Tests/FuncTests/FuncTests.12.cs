#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_12_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<object, StructType, DateTime, RefType, RecordType?, long, string, RefType, RecordType, decimal, object, long, StructType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void From_12_ThenInvoke_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult)
    {
        var actual = Func.From<RecordType, RefType, int, string?, StructType, RefType, RecordType, decimal?, RecordType?, RefType, long, int, RecordType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            MinusFifteenIdSomeStringNameRecord, MinusFifteenIdRefType, int.MaxValue, null, LowerSomeTextStructType, PlusFifteenIdRefType, ZeroIdNullNameRecord, default, default, PlusFifteenIdRefType, long.MaxValue, PlusFifteen);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
