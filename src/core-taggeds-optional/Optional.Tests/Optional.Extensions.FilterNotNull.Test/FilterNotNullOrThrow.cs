#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FilterNotNullOptionalExtensionsTest
    {
        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNotNull_ExpectSource()
        {
            var source = Optional<RefType?>.Present(ZeroIdRefType);

            var actual = source.FilterNotNullOrThrow();
            Assert.AreEqual(source, actual);
        }

        [Test]
        public void FilterNotNullOrThrow_SourceValueIsNull_ExpectInvalidOperationException()
        {
            var source = Optional<StructType?>.Present(null);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.FilterNotNullOrThrow());
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_ExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FilterNotNullOrThrow(null!));
            Assert.AreEqual("exceptionFactory", ex.ParamName);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNotNull_ExpectSource()
        {
            var source = Optional<RefType?>.Present(ZeroIdRefType);

            var actual = source.FilterNotNullOrThrow(() => new SomeException());
            Assert.AreEqual(source, actual);
        }

        [Test]
        public void FilterNotNullOrThrowWithFactory_SourceValueIsNull_ExpectCreatedException()
        {
            var source = Optional<StructType?>.Present(null);
            var resultException = new SomeException();

            var ex = Assert.Throws<SomeException>(() => _ = source.FilterNotNullOrThrow(() => resultException));
            Assert.AreSame(resultException, ex);
        }
    }
}
