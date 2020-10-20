#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    public sealed class OptionalSamenessComparerTest
    {
        [Test]
        public void Equals_AIsAbsentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Absent;

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsDefaultAndBIsAbsent_ExpectTrue()
        {
            var optionalA = default(Optional<RefType>);
            var optionalB = Optional<RefType>.Absent;

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsAbsentAndBIsDefault_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = default(Optional<RefType>);

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AAndBIsSamePresent_ExpectTrue()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = optionalA;

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreEquals_ExpectFalse()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = Optional<RefType>.Present(value);

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreNull_ExpectFalse()
        {
            var optionalA = Optional<StructType?>.Present(null);
            var optionalB = Optional<StructType?>.Present(null);

            var actual = OptionalSamenessComparer<StructType?>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsAbsentAndBIsPresent_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Present(MinusFifteenIdRefType);

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Present(default);
            var optionalB = Optional<StructType>.Absent;

            var actual = OptionalSamenessComparer<StructType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreNotEquals_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Present(PlusFifteenIdRefType);
            var optionalB = Optional<RefType>.Present(ZeroIdRefType);

            var actual = OptionalSamenessComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsAbsentAndOtherIsSameAbsent_ExpectSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Absent;

            var sourceHashCode = OptionalSamenessComparer<StructType>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<StructType>.Default.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceAndOtherIsSamePresent_ExpectSameValues()
        {
            var source = Optional<RefType>.Present(PlusFifteenIdRefType);
            var other = source;

            var sourceHashCode = OptionalSamenessComparer<RefType>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<RefType>.Default.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreEquals_ExpectNotSameValues()
        {
            var value = PlusFifteenIdRefType;

            var source = Optional<RefType>.Present(value);
            var other = Optional<RefType?>.Present(value);

            var sourceHashCode = OptionalSamenessComparer<RefType>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<RefType?>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNull_ExpectNotSameValues()
        {
            var source = Optional<RefType?>.Present(null);
            var other = Optional<RefType?>.Present(null);

            var sourceHashCode = OptionalSamenessComparer<RefType?>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<RefType?>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsAbsentAndOtherIsPresent_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Present(default);

            var sourceHashCode = OptionalSamenessComparer<StructType>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<StructType>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsAbsent_ExpectNotSameValues()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var other = Optional<RefType>.Absent;

            var sourceHashCode = OptionalSamenessComparer<RefType>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<RefType>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNotEquals_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = Optional<StructType>.Present(NullTextStructType);

            var sourceHashCode = OptionalSamenessComparer<StructType>.Default.GetHashCode(source);
            var otherHashCode = OptionalSamenessComparer<StructType>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
