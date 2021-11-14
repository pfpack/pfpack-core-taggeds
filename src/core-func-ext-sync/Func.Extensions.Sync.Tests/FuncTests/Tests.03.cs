using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_03_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, int, RecordType, StructType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.BooleanNullable), MemberType = typeof(TestCaseSources))]
    public void From_03_ThenInvoke_ExpectResultOfSourceFunc(
        bool? sourceFuncResult)
    {
        var actual = Func.From<StructType?, RefType, RecordType, bool?>(
            (_, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            SomeTextStructType, default!, MinusFifteenIdSomeStringNameRecord);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
