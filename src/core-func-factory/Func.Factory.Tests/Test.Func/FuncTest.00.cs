#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests
{
    partial class FuncTest
    {
        [Fact]
        public void Create_00_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Create_00_ThenInvoke_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = Func.Create(
                () => sourceFuncResult);

            var actualResult = actual.Invoke();
            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}