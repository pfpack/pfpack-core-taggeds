#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class NotNullExtensionsTest
    {
        [Test]
        public void FilterNotNullOrThrowThenMap_SourceValueIsNotNullRefType_ExpectPresentNotNullable()
        {
            var sourceValue = PlusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrowThenMap();
            var expected = Optional<RefType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrowThenMap_SourceValueIsNullRefType_ExpectInvalidOperationException()
        {
            var source = Optional<RefType?>.Present(null);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.FilterNotNullOrThrowThenMap());
        }

        [Test]
        public void FilterNotNullOrThrowThenMapWithFactory_RefTypeExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<RefType?>.Present(PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FilterNotNullOrThrowThenMap(null!));
            Assert.AreEqual("exceptionFactory", ex.ParamName);
        }

        [Test]
        public void FilterNotNullOrThrowThenMapWithFactory_SourceValueIsNotNullRefType_ExpectPresentNotNullable()
        {
            var sourceValue = PlusFifteenIdRefType;
            var source = Optional<RefType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrowThenMap(() => new SomeException());
            var expected = Optional<RefType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrowThenMapWithFactory_SourceValueIsNullRefType_ExpectCreatedException()
        {
            var source = Optional<RefType?>.Present(null);
            var createdException = new SomeException();

            var actualExcepton = Assert.Throws<SomeException>(
                () => _ = source.FilterNotNullOrThrowThenMap(() => createdException));
            Assert.AreSame(createdException, actualExcepton);
        }

        [Test]
        public void FilterNotNullOrThrowThenMap_SourceValueIsNotNullStructType_ExpectPresentNotNullable()
        {
            var sourceValue = SomeTextStructType;
            var source = Optional<StructType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrowThenMap();
            var expected = Optional<StructType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrowThenMap_SourceValueIsNullStructType_ExpectInvalidOperationException()
        {
            var source = Optional<StructType?>.Present(null);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.FilterNotNullOrThrowThenMap());
        }

        [Test]
        public void FilterNotNullOrThrowThenMapWithFactory_StructExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<StructType?>.Present(null);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FilterNotNullOrThrowThenMap(null!));
            Assert.AreEqual("exceptionFactory", ex.ParamName);
        }

        [Test]
        public void FilterNotNullOrThrowThenMapWithFactory_SourceValueIsNotNullStructType_ExpectPresentNotNullable()
        {
            var sourceValue = NullTextStructType;
            var source = Optional<StructType?>.Present(sourceValue);

            var actual = source.FilterNotNullOrThrowThenMap(() => new SomeException());
            var expected = Optional<StructType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterNotNullOrThrowThenMapWithFactory_SourceValueIsNullStructType_ExpectCreatedException()
        {
            var source = Optional<StructType?>.Present(null);
            var createdException = new SomeException();

            var actualExcepton = Assert.Throws<SomeException>(
                () => _ = source.FilterNotNullOrThrowThenMap(() => createdException));
            Assert.AreSame(createdException, actualExcepton);
        }
    }
}
