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
        public void Create_09_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, RecordType, RecordType?, DateTimeOffset, object, string, StructType?, string?, int, StructType>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Create_09_ThenInvoke_ExpectResultOfSourceFunc(
            RecordType sourceFuncResult)
        {
            var actual = Func.Create<int, RecordType?, RefType?, long, decimal, RefType?, object, int, string?, RecordType>(
                (_, _, _, _, _, _, _, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                PlusFifteen, default, MinusFifteenIdRefType, long.MinValue, decimal.One, ZeroIdRefType, PlusFifteenIdLowerSomeStringNameRecord, int.MinValue, TabString);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}