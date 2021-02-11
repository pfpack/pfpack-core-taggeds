#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class AsyncFuncTest
    {
        [Fact]
        public void Create_03_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RecordType?, StructType, string, CancellationToken, ValueTask<RefType?>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public async Task Create_03_ThenInvokeAsync_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = Func.Create<string?, RefType, RecordType?, StructType>(
                (_, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: false);

            var actualResult = await actual.InvokeAsync(
                LowerSomeString, ZeroIdRefType, PlusFifteenIdLowerSomeStringNameRecord, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}