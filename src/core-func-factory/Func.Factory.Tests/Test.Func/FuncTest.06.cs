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
        public void Create_06_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<string, Guid, RecordType?, RefType?, object?, DateTime, StructType>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Create_06_ThenInvoke_ExpectResultOfSourceFunc(
            RecordType sourceFuncResult)
        {
            var actual = Func.Create<object, string, RecordType?, int, StructType, RefType, RecordType>(
                (_, _, _, _, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                new(), TabString, PlusFifteenIdLowerSomeStringNameRecord, int.MaxValue, SomeTextStructType, null!);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}