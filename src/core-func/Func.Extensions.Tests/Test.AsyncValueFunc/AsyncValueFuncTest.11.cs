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
        public void From_11_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RecordType?, string, StructType, long?, object, DateTimeKind, RefType?, decimal, object, RecordType, byte, CancellationToken, ValueTask<DateTime>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
            Assert.Equal("funcAsync", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public async ValueTask From_11_ThenInvokeAsync_ExpectResultOfSourceFunc(
            RefType? sourceFuncResult)
        {
            var actual = AsyncValueFunc.From<StructType, RefType?, long, string, RefType, object, long, DateTimeKind, RefType, object, StructType?, RefType?>(
                (_, _, _, _, _, _, _, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: true);

            var actualResult = await actual.InvokeAsync(
                LowerSomeTextStructType, default, long.MaxValue, UpperSomeString, PlusFifteenIdRefType, null!, long.MinValue, DateTimeKind.Utc, null!, MinusFifteenIdRefType, SomeTextStructType, cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}