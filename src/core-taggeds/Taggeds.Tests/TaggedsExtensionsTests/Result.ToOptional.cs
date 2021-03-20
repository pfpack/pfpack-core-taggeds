#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedsExtensionsTests
    {
        [Test]
        public void Result_ToOptional_SourceResultIsDefault_ExpectAbsent()
        {
            var sourceResult = default(Result<SomeRecord?, Unit>);

            var actual = sourceResult.ToOptional();
            var expected = Optional<SomeRecord?>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Result_ToOptional_SourceResultIsFailure_ExpectUnionSecondOfSourceFailureValue()
        {
            var sourceResult = Result<RefType, Unit>.Failure(Unit.Value);

            var actual = sourceResult.ToOptional();
            var expected = Optional<RefType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Result_ToOptional_SourceResultIsSuccessAndSourceValueIsNull_ExpectPresentOptionalOfNullValue()
        {
            var sourceResult = Result<object?, Unit>.Success(null);

            var actual = sourceResult.ToOptional();
            var expected = Optional<object?>.Present(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Result_ToOptional_SourceResultIsSuccessAndSourceValueIsNotNull_ExpectPresentOptionalOfSourceValue()
        {
            var sourceValue = PlusFifteenIdRefType;
            var sourceResult = Result<RefType, Unit>.Success(PlusFifteenIdRefType);

            var actual = sourceResult.ToOptional();
            var expected = Optional<RefType>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }
    }
}