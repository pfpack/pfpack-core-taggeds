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
        public void Create_12_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<string, int, decimal?, object?, RefType, StructType?, DateTime?, RecordType, int, StructType, object?, string?, CancellationToken, ValueTask<RefType?>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public async Task Create_12_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RecordType? sourceFuncResult)
        {
            var actual = Func.Create<int, object, RecordType?, RefType, object, string?, string, decimal, byte, RecordType, StructType, object, RecordType?>(
                (_, _, _, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);

            var actualResult = await actual.InvokeAsync(
                PlusFifteen, new { Name = UpperSomeString }, null, PlusFifteenIdRefType, null!, SomeString, EmptyString, decimal.MinusOne, byte.MaxValue, MinusFifteenIdSomeStringNameRecord, LowerSomeTextStructType, SomeTextStructType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}