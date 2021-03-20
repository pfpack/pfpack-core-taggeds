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
        public void From_15_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType, int?, string, RefType?, StructType, DateTimeKind?, DateTime, int, byte, string, RecordType?, object, decimal, long, StructType?, CancellationToken, Task<RecordType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public async Task From_15_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = AsyncFunc.From<StructType?, string, long, object?, int, RefType, RecordType, decimal, string?, byte, object, RefType?, object?, decimal?, byte?, RefType?>(
                (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);

            var actualResult = await actual.InvokeAsync(
                LowerSomeTextStructType, SomeString, long.MaxValue, null, MinusFifteen, PlusFifteenIdRefType, PlusFifteenIdLowerSomeStringNameRecord, decimal.One, ThreeWhiteSpacesString, byte.MaxValue, new { Name = SomeString }, ZeroIdRefType, new(), decimal.MaxValue, null, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}