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
        public void Create_08_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<long, object, RefType?, string?, Guid, RecordType, StructType, RefType, RecordType?>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Create_08_ThenInvoke_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = Func.Create<StructType, RecordType?, object, int, string, RefType, StructType?, string, RefType?>(
                (_, _, _, _, _, _, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                SomeTextStructType, PlusFifteenIdLowerSomeStringNameRecord, new(), MinusFifteen, SomeString, PlusFifteenIdRefType, null, EmptyString);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}