#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_14_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<string, object?, decimal, RecordType, RefType, RecordType?, DateTimeOffset?, long, object, DateTime, RefType?, StructType, object, string, RefType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void From_14_ThenInvoke_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult)
    {
        var actual = Func.From<string, int, StructType, long, decimal?, RecordType, RefType?, string?, StructType?, RefType, object, int, string, decimal?, RecordType?>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            LowerSomeString, PlusFifteen, SomeTextStructType, default, decimal.MinusOne, MinusFifteenIdNullNameRecord, PlusFifteenIdRefType, SomeString, NullTextStructType, PlusFifteenIdRefType, ZeroIdRefType, MinusFifteen, EmptyString, decimal.One);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
