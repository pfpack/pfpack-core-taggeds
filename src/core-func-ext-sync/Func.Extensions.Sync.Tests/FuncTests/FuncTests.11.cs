#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_11_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<string, RecordType?, RefType, long, DateTime, object, string?, StructType, int, RefType?, object, RecordType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void From_11_ThenInvoke_ExpectResultOfSourceFunc(
        StructType sourceFuncResult)
    {
        var actual = Func.From<RecordType?, string, object, DateTimeKind, RecordType, RefType, StructType?, RefType?, byte, object, StructType, StructType>(
            (_, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            MinusFifteenIdSomeStringNameRecord, UpperSomeString, null!, DateTimeKind.Utc, MinusFifteenIdNullNameRecord, PlusFifteenIdRefType, SomeTextStructType, ZeroIdRefType, Zero, new(), LowerSomeTextStructType);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
