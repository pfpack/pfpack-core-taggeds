#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void Same_AIsAbsentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Absent;

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AIsDefaultAndBIsAbsent_ExpectTrue()
        {
            var optionalA = default(Optional<RefType>);
            var optionalB = Optional<RefType>.Absent;

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AIsAbsentAndBIsDefault_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = default(Optional<RefType>);

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AAndBIsSamePresent_ExpectTrue()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = optionalA;

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsPresentAndValuesAreSame_ExpectFalse()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = Optional<RefType>.Present(value);

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsPresentAndValuesAreNull_ExpectFalse()
        {
            var optionalA = Optional<StructType?>.Present(null);
            var optionalB = Optional<StructType?>.Present(null);

            var actual = Optional<StructType?>.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsAbsentAndBIsPresent_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Present(MinusFifteenIdRefType);

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Present(default);
            var optionalB = Optional<StructType>.Absent;

            var actual = Optional<StructType>.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Present(PlusFifteenIdRefType);
            var optionalB = Optional<RefType>.Present(ZeroIdRefType);

            var actual = Optional<RefType>.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void SameWithOther_SourceIsAbsentAndOtherIsAbsent_ExpectTrue()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Absent;

            var actual = source.Same(other);
            Assert.True(actual);
        }

        [Test]
        public void SameWithOther_SourceAndOtherIsSamePresent_ExpectTrue()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = source;

            var actual = source.Same(other);
            Assert.True(actual);
        }

        [Test]
        public void SameWithOther_SourceIsPresentAndOtherIsPresentAndValuesAreSame_ExpectFalse()
        {
            var value = SomeTextStructType;

            var source = Optional<StructType>.Present(value);
            var other = Optional<StructType>.Present(value);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void SameWithOther_SourceIsPresentAndOtherIsPresentAndValuesAreNull_ExpectFalse()
        {
            var source = Optional<RefType?>.Present(null);
            var other = Optional<RefType?>.Present(null);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void SameWithOther_SourceIsAbsentAndOtherIsPresent_ExpectFalse()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Present(default);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void SameWithOther_SourceIsPresentAndOtherIsAbsent_ExpectFalse()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var other = Optional<RefType>.Absent;

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void SameWithOther_SourceIsPresentAndOtherIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = Optional<StructType>.Present(NullTextStructType);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsAbsentAndOtherIsSameAbsent_ExpectSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Absent;

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceAndOtherIsSamePresent_ExpectSameValues()
        {
            var source = Optional<RefType>.Present(PlusFifteenIdRefType);
            var other = source;

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreSame_ExpectNotSameValues()
        {
            var value = PlusFifteenIdRefType;

            var source = Optional<RefType>.Present(value);
            var other = Optional<RefType?>.Present(value);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNull_ExpectNotSameValues()
        {
            var source = Optional<RefType?>.Present(null);
            var other = Optional<RefType?>.Present(null);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsAbsentAndOtherIsPresent_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Absent;
            var other = Optional<StructType>.Present(default);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsAbsent_ExpectNotSameValues()
        {
            var source = Optional<RefType>.Present(MinusFifteenIdRefType);
            var other = Optional<RefType>.Absent;

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsPresentAndOtherIsPresentAndValuesAreNotSame_ExpectNotSameValues()
        {
            var source = Optional<StructType>.Present(SomeTextStructType);
            var other = Optional<StructType>.Present(NullTextStructType);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
