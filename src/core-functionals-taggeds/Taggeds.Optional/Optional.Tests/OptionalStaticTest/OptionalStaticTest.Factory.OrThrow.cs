#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalStaticTest
    {
        [Test]
        public void PresentOrThrow_ValueIsNotNull_ExpectPresent()
        {
            var sourceValue = PlusFifteenIdRefType;

            var actual = Optional.PresentOrThrow<RefType?>(sourceValue);
            var expected = Optional<RefType?>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PresentOrThrow_ValueIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Optional.PresentOrThrow<RefType?>(null!));
            Assert.AreEqual("value", ex.ParamName);
        }

        [Test]
        public void PresentOrThrowWithStructValue_ValueIsNotNull_ExpectPresent()
        {
            var sourceValue = SomeTextStructType;

            var actual = Optional.PresentOrThrow(sourceValue);
            var expected = Optional<StructType>.Present(SomeTextStructType);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PresentOrThrowWithStructValue_ValueIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Optional.PresentOrThrow<StructType>(null!));
            Assert.AreEqual("value", ex.ParamName);
        }
    }
}
