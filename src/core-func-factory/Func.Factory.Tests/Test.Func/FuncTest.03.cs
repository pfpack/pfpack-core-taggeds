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
        public void Create_03_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, int, RecordType, StructType>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(true)]
        [InlineData(false)]
        public void Create_03_ThenInvoke_ExpectResultOfSourceFunc(
            bool? sourceFuncResult)
        {
            var actual = Func.Create<StructType?, RefType, RecordType, bool?>(
                (_, _, _) => sourceFuncResult);

            var actualResult = actual.Invoke(
                SomeTextStructType, default!, MinusFifteenIdSomeStringNameRecord);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}