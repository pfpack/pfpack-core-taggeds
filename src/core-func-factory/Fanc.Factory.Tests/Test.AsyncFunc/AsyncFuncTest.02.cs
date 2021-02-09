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
        public void Create_02_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, RecordType, CancellationToken, ValueTask<StructType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Create_02_ThenInvokeAsync_ExpectResultOfSourceFunc(
            bool? sourceFuncResult)
        {
            var actual = Func.Create<RecordType?, StructType, bool?>(
                (_, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);
            var actualResult = await actual.InvokeAsync(MinusFifteenIdNullNameRecord, default, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}