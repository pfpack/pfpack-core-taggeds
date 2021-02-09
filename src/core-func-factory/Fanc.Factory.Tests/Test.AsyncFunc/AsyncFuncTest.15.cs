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
        public void Create_15_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType, int?, string, RefType?, StructType, DateTimeKind?, DateTime, int, byte, string, RecordType?, object, decimal, long, StructType?, CancellationToken, ValueTask<RecordType>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public async Task Create_15_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = Func.Create<StructType?, string, long, object?, int, RefType, RecordType, decimal, string?, byte, object, RefType?, object?, decimal?, byte?, RefType?>(
                (_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);

            var actualResult = await actual.InvokeAsync(
                LowerSomeTextStructType, SomeString, long.MaxValue, null, MinusFifteen, PlusFifteenIdRefType, PlusFifteenIdLowerSomeStringNameRecord, decimal.One, ThreeWhiteSpacesString, byte.MaxValue, new { Name = SomeString }, ZeroIdRefType, new object(), decimal.MaxValue, null, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}