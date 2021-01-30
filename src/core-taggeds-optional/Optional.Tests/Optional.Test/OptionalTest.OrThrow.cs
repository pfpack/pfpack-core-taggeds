#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void OrThrow_SourceIsPresent_ExpectSourceValue(
            object? sourceValue)
        {
            var source = Optional<object?>.Present(sourceValue);

            var actual = source.OrThrow();
            Assert.AreEqual(sourceValue, actual);
        }

        [Test]
        public void OrThrow_SourceIsAbsent_ExpectInvalidOperationException()
        {
            var source = Optional<StructType>.Absent;
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.OrThrow());
        }

        [Test]
        public void OrThrowWithFactory_ExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.OrThrow(null!));
            Assert.AreEqual("exceptionFactory", ex!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void OrThrowWithFactory_SourceIsPresent_ExpectSourceValue(
            object? sourceValue)
        {
            var source = Optional<object?>.Present(sourceValue);

            var actual = source.OrThrow(() => new SomeException());
            Assert.AreEqual(sourceValue, actual);
        }

        [Test]
        public void OrThrowWithFactory_SourceIsAbsent_ExpectFactoryResultException()
        {
            var source = Optional<StructType>.Absent;
            var resultException = new SomeException();

            var actualException = Assert.Throws<SomeException>(() => _ = source.OrThrow(() => resultException));
            Assert.AreSame(resultException, actualException);
        }
    }
}
