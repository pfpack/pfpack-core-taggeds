#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FuncTest
    {
        [Fact]
        public void Create_15_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<StructType, string, object?, decimal, RecordType, RefType, RecordType?, DateTimeOffset?, long, object, DateTime, RefType?, StructType, object, string, RefType?>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Create_15_ThenInvoke_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = Func.Create<decimal, object, object?, decimal, RecordType?, object, long, int, RecordType, string, long, RefType?, StructType?, string, object, StructType>(
                (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                decimal.MinusOne, new(), null, decimal.MaxValue, PlusFifteenIdLowerSomeStringNameRecord, new { Sum = PlusFifteen }, long.MaxValue, MinusFifteen, MinusFifteenIdSomeStringNameRecord, SomeString, long.MinValue, null, null, WhiteSpaceString, SomeTextStructType);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}