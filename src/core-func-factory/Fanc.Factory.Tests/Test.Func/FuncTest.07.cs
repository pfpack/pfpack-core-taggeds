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
        public void Create_07_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<Guid, RecordType, object?, DateTime?, RefType?, RecordType?, StructType, string>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Create_07_ThenInvoke_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = Func.Create<object, string, RecordType?, RefType, int?, RefType?, long, StructType>(
                (_, _, _, _, _, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                new { Name = LowerSomeString }, UpperSomeString, null, MinusFifteenIdRefType, PlusFifteen, PlusFifteenIdRefType, long.MaxValue);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}