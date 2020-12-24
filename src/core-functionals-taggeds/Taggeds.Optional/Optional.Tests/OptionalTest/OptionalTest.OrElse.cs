#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalTest
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void OrElse_SourceIsPresent_ExpectSourceValue(
            bool isSourceNull)
        {
            var sourceValue = isSourceNull ? null : PlusFifteenIdRefType;
            var otherValue = MinusFifteenIdRefType;

            var source = Optional<RefType?>.Present(sourceValue);
            var actual = source.OrElse(otherValue);

            Assert.AreSame(sourceValue, actual);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void OrElse_SourceIsAbsent_ExpectOtherValue(
            bool isOtherNull)
        {
            var otherValue = isOtherNull ? null : (StructType?)SomeTextStructType;

            var source = Optional<StructType?>.Absent;
            var actual = source.OrElse(otherValue);

            Assert.AreEqual(otherValue, actual);
        }

        [Test]
        public void OrElseWithFactory_OtherFactoryIsNull_ExpectArgumentNullExcepton()
        {
            var source = Optional<int>.Present(PlusFifteen);
            Func<int> otherFactory = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.OrElse(otherFactory));
            Assert.AreEqual("otherFactory", ex.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void OrElseWithFactory_SourceIsPresent_ExpectSourceValue(
            bool isSourceNull)
        {
            var sourceValue = isSourceNull ? null : PlusFifteenIdRefType;
            var otherValue = MinusFifteenIdRefType;

            var source = Optional<RefType?>.Present(sourceValue);
            var actual = source.OrElse(() => otherValue);

            Assert.AreSame(sourceValue, actual);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void OrElseWithFactory_SourceIsAbsent_ExpectOtherValue(
            bool isOtherNull)
        {
            var otherValue = isOtherNull ? null : (StructType?)SomeTextStructType;

            var source = Optional<StructType?>.Absent;
            var actual = source.OrElse(() => otherValue);

            Assert.AreEqual(otherValue, actual);
        }

        [Test]
        public void OrElseAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullExcepton()
        {
            var source = Optional<int>.Present(PlusFifteen);

            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.OrElseAsync(null!));
            Assert.AreEqual("otherFactoryAsync", ex.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OrElseAsync_SourceIsPresent_ExpectSourceValue(
            bool isSourceNull)
        {
            var sourceValue = isSourceNull ? null : PlusFifteenIdRefType;
            var otherValue = MinusFifteenIdRefType;

            var source = Optional<RefType?>.Present(sourceValue);
            var actual = await source.OrElseAsync(() => Task.FromResult<RefType?>(otherValue));

            Assert.AreSame(sourceValue, actual);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OrElseAsync_SourceIsAbsent_ExpectOtherValue(
            bool isOtherNull)
        {
            var otherValue = isOtherNull ? null : (StructType?)SomeTextStructType;

            var source = Optional<StructType?>.Absent;
            var actual = await source.OrElseAsync(() => Task.FromResult(otherValue));

            Assert.AreEqual(otherValue, actual);
        }

        [Test]
        public void OrElseValueAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullExcepton()
        {
            var source = Optional<int>.Present(PlusFifteen);

            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.OrElseValueAsync(null!));
            Assert.AreEqual("otherFactoryAsync", ex.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OrElseValueAsync_SourceIsPresent_ExpectSourceValue(
            bool isSourceNull)
        {
            var sourceValue = isSourceNull ? null : ZeroIdRefType;
            var otherValue = MinusFifteenIdRefType;

            var source = Optional<RefType?>.Present(sourceValue);
            var actual = await source.OrElseValueAsync(() => ValueTask.FromResult<RefType?>(otherValue));

            Assert.AreSame(sourceValue, actual);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OrElseValueAsync_SourceIsAbsent_ExpectOtherValue(
            bool isOtherNull)
        {
            var otherValue = isOtherNull ? null : (StructType?)NullTextStructType;

            var source = Optional<StructType?>.Absent;
            var actual = await source.OrElseValueAsync(() => ValueTask.FromResult(otherValue));

            Assert.AreEqual(otherValue, actual);
        }
    }
}
