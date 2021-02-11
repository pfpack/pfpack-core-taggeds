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
        public void Create_02_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<decimal, string?, StructType?>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Create_02_ThenInvoke_ExpectResultOfSourceFunc(
            RecordType sourceFuncResult)
        {
            var actual = Func.Create<long, RefType, RecordType>(
                (_, _) => sourceFuncResult);

            var actualResult = actual.Invoke(long.MaxValue, PlusFifteenIdRefType);
            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}