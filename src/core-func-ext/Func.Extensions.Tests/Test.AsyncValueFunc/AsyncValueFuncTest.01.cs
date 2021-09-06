#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class AsyncValueFuncTest
    {
        [Fact]
        public void From_01_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<StructType?, CancellationToken, ValueTask<RefType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public async ValueTask From_01_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RecordType? sourceFuncResult)
        {
            var actual = AsyncValueFunc.From<RefType, RecordType?>((_, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = default(CancellationToken);
            var actualResult = await actual.InvokeAsync(PlusFifteenIdRefType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}