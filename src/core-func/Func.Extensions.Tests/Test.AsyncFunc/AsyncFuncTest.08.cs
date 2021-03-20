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
        public void From_08_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<DateTimeOffset, object, RefType?, Guid, RecordType, StructType?, string, long, CancellationToken, Task<RecordType?>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public async Task From_08_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = AsyncFunc.From<object, RefType?, DateTimeKind, RecordType, int, string, StructType, RecordType, RefType?>(
                (_, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: false);

            var actualResult = await actual.InvokeAsync(
                new { Id = PlusFifteen }, default, DateTimeKind.Local, PlusFifteenIdLowerSomeStringNameRecord, MinusFifteen, null!, SomeTextStructType, MinusFifteenIdSomeStringNameRecord, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}