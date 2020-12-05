#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    public sealed class OptionalEqualityComparerTest
    {
        [Test]
        public void Equals_AIsAbsentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Absent;

            var actual = OptionalEqualityComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsDefaultAndBIsAbsent_ExpectTrue()
        {
            var optionalA = default(Optional<RefType>);
            var optionalB = Optional<RefType>.Absent;

            var actual = OptionalEqualityComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsAbsentAndBIsDefault_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = default(Optional<RefType>);

            var actual = OptionalEqualityComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreSame_ExpectTrue()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = Optional<RefType>.Present(value);

            var actual = OptionalEqualityComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreNull_ExpectTrue()
        {
            var optionalA = Optional<StructType?>.Present(null);
            var optionalB = Optional<StructType?>.Present(null);

            var actual = OptionalEqualityComparer<StructType?>.Default.Equals(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_AIsAbsentAndBIsPresent_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Present(MinusFifteenIdRefType);

            var actual = OptionalEqualityComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Present(default);
            var optionalB = Optional<StructType>.Absent;

            var actual = OptionalEqualityComparer<StructType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Present(PlusFifteenIdRefType);
            var optionalB = Optional<RefType>.Present(ZeroIdRefType);

            var actual = OptionalEqualityComparer<RefType>.Default.Equals(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void GetHashCode_SourceIsAbsentAndOtherIsSameAbsent_ExpectSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Absent;

            var sourceHashCode = OptionalEqualityComparer<StructType>.Default.GetHashCode(source);
            var otherHashCode = OptionalEqualityComparer<StructType>.Default.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreSame_ExpectSameValues()
        {
            var value = PlusFifteenIdRefType;

            var source = Optional<RefType>.Present(value);
            var other = Optional<RefType?>.Present(value);

            var sourceHashCode = OptionalEqualityComparer<RefType>.Default.GetHashCode(source);
            var otherHashCode = OptionalEqualityComparer<RefType?>.Default.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNull_ExpectSameValues()
        {
            var source = Optional<RefType?>.Present(null);
            var other = Optional<RefType?>.Present(null);

            var sourceHashCode = OptionalEqualityComparer<RefType?>.Default.GetHashCode(source);
            var otherHashCode = OptionalEqualityComparer<RefType?>.Default.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsAbsentAndOtherIsPresent_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Present(default);

            var sourceHashCode = OptionalEqualityComparer<StructType>.Default.GetHashCode(source);
            var otherHashCode = OptionalEqualityComparer<StructType>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsAbsent_ExpectNotSameValues()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var other = Optional<RefType>.Absent;

            var sourceHashCode = OptionalEqualityComparer<RefType>.Default.GetHashCode(source);
            var otherHashCode = OptionalEqualityComparer<RefType>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNotSame_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = Optional<StructType>.Present(NullTextStructType);

            var sourceHashCode = OptionalEqualityComparer<StructType>.Default.GetHashCode(source);
            var otherHashCode = OptionalEqualityComparer<StructType>.Default.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
