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
        public void Create_05_SourceFuncIsNull_ExpectArgumentNullException()
        {
            var sourceFunc = (Func<RefType?, object, Guid, StructType, RecordType, CancellationToken, ValueTask<string?>>)null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.Create(sourceFunc));
            Assert.Equal("func", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public async Task Create_05_ThenInvokeAsync_ExpectResultOfSourceFunc(
            StructType sourceFuncResult)
        {
            var actual = Func.Create<int?, RecordType, RefType?, string, object, StructType>(
                (_, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

            var cancellationToken = new CancellationToken(canceled: false);

            var actualResult = await actual.InvokeAsync(
                MinusFifteen, PlusFifteenIdSomeStringNameRecord, null, SomeString, new(), cancellationToken);

            Assert.Equal(sourceFuncResult, actualResult);
        }
    }
}