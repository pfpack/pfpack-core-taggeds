#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void Equals_AIsAbsentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Absent;

            var actual = Optional<RefType>.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsDefaultAndBIsAbsent_ExpectTrue()
        {
            var optionalA = default(Optional<RefType>);
            var optionalB = Optional<RefType>.Absent;

            var actual = Optional<RefType>.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsAbsentAndBIsDefault_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = default(Optional<RefType>);

            var actual = Optional<RefType>.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreSame_ExpectTrue()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = Optional<RefType>.Present(value);

            var actual = Optional<RefType>.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreNull_ExpectTrue()
        {
            var optionalA = Optional<StructType?>.Present(null);
            var optionalB = Optional<StructType?>.Present(null);

            var actual = Optional<StructType?>.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsAbsentAndBIsPresent_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Present(MinusFifteenIdRefType);

            var actual = Optional<RefType>.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Present(default);
            var optionalB = Optional<StructType>.Absent;

            var actual = Optional<StructType>.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Present(PlusFifteenIdRefType);
            var optionalB = Optional<RefType>.Present(ZeroIdRefType);

            var actual = Optional<RefType>.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void EqualityOperator_AIsAbsentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<StructType>.Absent;
            var optionalB = Optional<StructType>.Absent;

            var actual = optionalA == optionalB;
            Assert.True(actual);
        }

        [Test]
        public void EqualityOperator_AIsPresentAndBIsPresentAndValuesAreSame_ExpectTrue()
        {
            var value = SomeTextStructType;

            var optionalA = Optional<StructType>.Present(value);
            var optionalB = Optional<StructType>.Present(value);

            var actual = optionalA == optionalB;
            Assert.True(actual);
        }

        [Test]
        public void EqualityOperator_AIsPresentAndBIsPresentAndValuesAreNull_ExpectTrue()
        {
            var optionalA = Optional<RefType?>.Present(null);
            var optionalB = Optional<RefType?>.Present(null);

            var actual = optionalA == optionalB;
            Assert.True(actual);
        }

        [Test]
        public void EqualityOperator_AIsAbsentAndBIsPresent_ExpectFalse()
        {
            var optionalA = Optional<RefType?>.Absent;
            var optionalB = Optional<RefType?>.Present(PlusFifteenIdRefType);

            var actual = optionalA == optionalB;
            Assert.False(actual);
        }

        [Test]
        public void EqualityOperator_AIsPresentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<RefType?>.Present(null);
            var optionalB = Optional<RefType?>.Absent;

            var actual = optionalA == optionalB;
            Assert.False(actual);
        }

        [Test]
        public void EqualityOperator_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Present(NullTextStructType);
            var optionalB = Optional<StructType>.Present(SomeTextStructType);

            var actual = optionalA == optionalB;
            Assert.False(actual);
        }

        [Test]
        public void InequalityOperator_AIsAbsentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Absent;
            var optionalB = Optional<StructType>.Absent;

            var actual = optionalA != optionalB;
            Assert.False(actual);
        }

        [Test]
        public void InequalityOperator_AIsPresentAndBIsPresentAndValuesAreSame_ExpectFalse()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = Optional<RefType>.Present(value);

            var actual = optionalA != optionalB;
            Assert.False(actual);
        }

        [Test]
        public void InequalityOperator_AIsPresentAndBIsPresentAndValuesAreNull_ExpectFalse()
        {
            var optionalA = Optional<StructType?>.Present(null);
            var optionalB = Optional<StructType?>.Present(null);

            var actual = optionalA != optionalB;
            Assert.False(actual);
        }

        [Test]
        public void InequalityOperator_AIsAbsentAndBIsPresent_ExpectTrue()
        {
            var optionalA = Optional<StructType?>.Absent;
            var optionalB = Optional<StructType?>.Present(SomeTextStructType);

            var actual = optionalA != optionalB;
            Assert.True(actual);
        }

        [Test]
        public void InequalityOperator_AIsPresentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<StructType>.Present(NullTextStructType);
            var optionalB = Optional<StructType>.Absent;

            var actual = optionalA != optionalB;
            Assert.True(actual);
        }

        [Test]
        public void InequalityOperator_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectTrue()
        {
            var optionalA = Optional<RefType?>.Present(ZeroIdRefType);
            var optionalB = Optional<RefType?>.Present(PlusFifteenIdRefType);

            var actual = optionalA != optionalB;
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsAbsentAndOtherIsAbsent_ExpectTrue()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Absent;

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsPresentAndOtherIsPresentAndValuesAreSame_ExpectTrue()
        {
            var value = SomeTextStructType;

            var source = Optional<StructType>.Present(value);
            var other = Optional<StructType>.Present(value);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsPresentAndOtherIsPresentAndValuesAreNull_ExpectTrue()
        {
            var source = Optional<RefType?>.Present(null);
            var other = Optional<RefType?>.Present(null);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsAbsentAndOtherIsPresent_ExpectFalse()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Present(default);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsPresentAndOtherIsAbsent_ExpectFalse()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var other = Optional<RefType>.Absent;

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsPresentAndOtherIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = Optional<StructType>.Present(NullTextStructType);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsAbsentAndObjectIsAbsent_ExpectTrue()
        {
            var source = Optional<StructType>.Absent;
            var obj = (object?)Optional<StructType>.Absent;

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsPresentAndValuesAreSame_ExpectTrue()
        {
            var value = SomeTextStructType;

            var source = Optional<StructType>.Present(value);
            var obj = (object?)Optional<StructType>.Present(value);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsPresentAndValuesAreNull_ExpectTrue()
        {
            var source = Optional<RefType?>.Present(null);
            var obj = (object?)Optional<RefType?>.Present(null);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsOptionalOfSameRefNullable_ExpectTrue()
        {
            var source = Optional<RefType>.Present(PlusFifteenIdRefType);
            var obj = (object?)Optional<RefType?>.Present(PlusFifteenIdRefType);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsAbsentAndObjectIsPresent_ExpectFalse()
        {
            var source = Optional<StructType>.Absent;
            var obj = (object?)Optional<StructType>.Present(default);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsAbsent_ExpectFalse()
        {
            var source = Optional<RefType>.Present(PlusFifteenIdRefType);
            var obj = (object?)Optional<RefType>.Absent;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var obj = (object?)Optional<StructType>.Present(NullTextStructType);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void EqualsWithObject_SourceIsAbsentAndObjectIsNotOptional_ExpectFalse(
            in object? obj)
        {
            var source = Optional<StructType>.Absent;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void EqualsWithObject_SourceIsPresentAndObjectIsNotOptional_ExpectFalse(
            in object? obj)
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsAbsentAndObjectIsOtherOptional_ExpectFalse()
        {
            var source = Optional<StructType>.Absent;
            var obj = Optional<RefType>.Absent;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsOtherOptional_ExpectFalse()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var obj = Optional<object>.Present(MinusFifteenIdRefType);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsPresentAndObjectIsOptionalOfSameStructNullable_ExpectFalse()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var obj = (object?)Optional<StructType?>.Present(SomeTextStructType);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void GetHashCode_SourceIsAbsentAndOtherIsSameAbsent_ExpectSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Absent;

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreSame_ExpectSameValues()
        {
            var value = PlusFifteenIdRefType;

            var source = Optional<RefType>.Present(value);
            var other = Optional<RefType?>.Present(value);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNull_ExpectSameValues()
        {
            var source = Optional<RefType?>.Present(null);
            var other = Optional<RefType?>.Present(null);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsAbsentAndOtherIsPresent_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Present(default);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsAbsent_ExpectNotSameValues()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var other = Optional<RefType>.Absent;

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNotSame_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = Optional<StructType>.Present(NullTextStructType);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
