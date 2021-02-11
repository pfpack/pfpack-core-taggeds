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
        public void Create_06_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, StructType, string, RecordType?, DateTimeKind, object, CancellationToken, ValueTask<RecordType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(WhiteSpaceString)]
        [InlineData(TabString)]
        [InlineData(LowerSomeString)]
        [InlineData(SomeString)]
        public async Task Create_06_ThenInvokeAsync_ExpectResultOfSourceFunc(
            string? sourceFuncResult)
        {
            var actual = Func.Create<RefType, string, StructType?, object, RecordType, int, string?>(
                (_, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken();

            var actualResult = await actual.InvokeAsync(
                MinusFifteenIdRefType, null!, new(), new(), PlusFifteenIdLowerSomeStringNameRecord, int.MaxValue, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}