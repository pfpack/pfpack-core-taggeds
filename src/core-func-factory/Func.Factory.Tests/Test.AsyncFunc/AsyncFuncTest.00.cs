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
        public void Create_00_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<CancellationToken, ValueTask<StructType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(null, true)]
        [InlineData(EmptyString, false)]
        [InlineData(EmptyString, true)]
        [InlineData(WhiteSpaceString, false)]
        [InlineData(WhiteSpaceString, true)]
        [InlineData(SomeString, false)]
        [InlineData(SomeString, true)]
        public async Task Create_00_ThenInvokeAsync_ExpectResultOfSourceFunc(
            string? sourceFuncResult, bool canceled)
        {
            var actual = Func.Create(_ => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: canceled);
            var actualResult = await actual.InvokeAsync(cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}