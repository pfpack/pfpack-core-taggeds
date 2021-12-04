using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class SuccessBuilderTest
    {
        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectHashCodesAreEqual()
        {
            var source = default(SuccessBuilder<RefType?>);
            var other = default(SuccessBuilder<RefType>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherSuccessIsNullAndTypesAreSame_ExpectHashCodesAreEqual()
        {
            var source = new SuccessBuilder<SomeRecord>();
            var other = Result.Success<SomeRecord?>(null);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectHashCodesAreEqual()
        {
            var source = Result.Success(default(SomeError));
            var other = new SuccessBuilder<SomeError>();

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsNullAndOtherSuccessIsNullAndTypesAreSame_ExpectHashCodesAreEqual()
        {
            var source = Result.Success<StructType?>(null);
            var other = Result.Success<StructType?>(null);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsEqualToOtherSuccessAndTypesAreSame_ExpectHashCodesAreEqual()
        {
            var someValue = MinusFifteen;

            var sourceSuccess = new SomeError(someValue);
            var source = Result.Success(sourceSuccess);

            var otherSuccess = new SomeError(someValue);
            var other = Result.Success(otherSuccess);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var source = new SuccessBuilder<int>();
            var other = new SuccessBuilder<int?>();

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();
            
            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherSuccessIsNullAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var source = new SuccessBuilder<SomeRecord?>();
            var other = Result.Success<object?>(null);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var source = Result.Success(default(StructType));
            var other = new SuccessBuilder<StructType?>();

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsNullAndOtherSuccessIsNullAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var source = Result.Success<object?>(null);
            var other = Result.Success<RefType?>(null);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsEqualToOtherSuccessAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
        {
            var someValue = MinusFifteen;
            var source = Result.Success(someValue);
            var other = Result.Success<long>(someValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsNotDefaultAndTypesAreSame_ExpectHashCodesAreNotEqual()
        {
            var source = new SuccessBuilder<RefType>();
            var other = Result.Success<RefType>(new());

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsNotEqualToOtherSuccessAndTypesAreSame_ExpectHashCodesAreNotEqual()
        {
            var sourceSuccess = new RefType();
            var source = Result.Success(sourceSuccess);

            var otherSuccess = new RefType();
            var other = Result.Success(otherSuccess);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsNullAndOtherSuccessIsNotNull_ExpectHashCodesAreNotEqual()
        {
            var source = Result.Success<SomeRecord?>(null);
            var other = Result.Success<SomeRecord?>(new());

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();
            
            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSuccessIsNotNullAndOtherSuccessIsNull_ExpectHashCodesAreNotEqual()
        {
            var source = Result.Success<object>(new());
            var other = Result.Success<object>(null!);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}