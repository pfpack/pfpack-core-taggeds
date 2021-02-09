#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests
{
    partial class FuncTest
    {
        [Fact]
        public void Create_01_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<int, RecordType>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Create_01_ThenInvoke_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = Func.Create<object, StructType>(
                _ => sourceFuncResult);

            var actualResult = actual.Invoke(new object());
            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}