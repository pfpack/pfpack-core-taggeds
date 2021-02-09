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
        public void Create_10_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RecordType?, object, string, DateTime?, int, StructType, long, RefType?, StructType?, RecordType, CancellationToken, ValueTask<string>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(Zero)]
        [InlineData(MinusFifteen)]
        [InlineData(PlusFifteen)]
        [InlineData(int.MaxValue)]
        public async Task Create_10_ThenInvokeAsync_ExpectResultOfSourceFunc(
            int? sourceFuncResult)
        {
            var actual = Func.Create<object?, StructType?, RefType?, RecordType?, int, string?, long, int?, RefType, StructType?, int?>(
                (_, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = default(CancellationToken);

            var actualResult = await actual.InvokeAsync(
                null, SomeTextStructType, PlusFifteenIdRefType, MinusFifteenIdSomeStringNameRecord, MinusFifteen, TabString, long.MinValue, Zero, MinusFifteenIdRefType, LowerSomeTextStructType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}