#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void SecondOrThrowWithFactory_ExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = TaggedUnion<StructType, RefType>.Second(MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SecondOrThrow(null!));
            Assert.AreEqual("exceptionFactory", ex.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void SecondOrThrowWithFactory_SourceIsSecond_ExpectSourceValue(
            object? sourceValue)
        {
            var source = TaggedUnion<RefType, object?>.Second(sourceValue);
            var resultException = new SomeException();

            var actual = source.SecondOrThrow(() => resultException);
            Assert.AreEqual(sourceValue, actual);
        }

        [Test]
        public void SecondOrThrowWithFactory_SourceIsFirst_ExpectCreatedException()
        {
            var source = TaggedUnion<RefType, object>.First(ZeroIdRefType);
            var resultException = new SomeException();

            var actualExcepption = Assert.Throws<SomeException>(
                () => _ = source.SecondOrThrow(() => resultException));

            Assert.AreSame(resultException, actualExcepption);
        }

        [Test]
        public void SecondOrThrowWithFactory_SourceIsDefault_ExpectInvalidOperationException()
        {
            var source = default(TaggedUnion<RefType, DateTime>);
            var resultException = new SomeException();

            var actualExcepption = Assert.Throws<SomeException>(
                () => _ = source.SecondOrThrow(() => resultException));

            Assert.AreSame(resultException, actualExcepption);
        }
    }
}