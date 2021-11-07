#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_05_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, StructType, string, RecordType?, object, int?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void From_05_ThenInvoke_ExpectResultOfSourceFunc(
        RefType? sourceFuncResult)
    {
        var actual = Func.From<StructType, object, string?, RecordType?, int, RefType?>(
            (_, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            SomeTextStructType, new(), null, MinusFifteenIdNullNameRecord, default);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
