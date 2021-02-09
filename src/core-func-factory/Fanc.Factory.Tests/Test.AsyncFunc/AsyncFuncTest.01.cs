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
        public void Create_01_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<StructType?, CancellationToken, ValueTask<RefType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public async Task Create_01_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RecordType? sourceFuncResult)
        {
            var actual = Func.Create<RefType, RecordType?>((_, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = default(CancellationToken);
            var actualResult = await actual.InvokeAsync(PlusFifteenIdRefType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}