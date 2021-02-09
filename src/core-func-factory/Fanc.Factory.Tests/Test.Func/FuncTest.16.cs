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
        public void Create_16_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<int, StructType?, string, object?, RefType, RecordType, int?, RecordType?, string?, long, decimal, DateTime, RefType?, StructType, object, string, DateTimeOffset>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Create_16_ThenInvoke_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = Func.Create<int, decimal, string, object?, string?, RefType?, StructType, object, int, decimal, string, long, int?, RecordType, byte, RecordType?, RefType?>(
                (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                PlusFifteen, default, EmptyString, null, SomeString, MinusFifteenIdRefType, SomeTextStructType, new object(), int.MaxValue, decimal.MinusOne, LowerSomeString, long.MinValue, null, MinusFifteenIdNullNameRecord, byte.MaxValue, null);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}