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
        public void Same_AIsAbsentAndBIsAbsent_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Absent;

            var actual = Optional.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AIsDefaultAndBIsAbsent_ExpectTrue()
        {
            var optionalA = default(Optional<RefType>);
            var optionalB = Optional<RefType>.Absent;

            var actual = Optional.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AIsAbsentAndBIsDefault_ExpectTrue()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = default(Optional<RefType>);

            var actual = Optional.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AAndBIsSamePresent_ExpectTrue()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = optionalA;

            var actual = Optional.Same(optionalA, optionalB);
            Assert.True(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsPresentAndValuesAreSame_ExpectFalse()
        {
            var value = PlusFifteenIdRefType;

            var optionalA = Optional<RefType>.Present(value);
            var optionalB = Optional<RefType>.Present(value);

            var actual = Optional.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsPresentAndValuesAreNull_ExpectFalse()
        {
            var optionalA = Optional<StructType?>.Present(null);
            var optionalB = Optional<StructType?>.Present(null);

            var actual = Optional.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsAbsentAndBIsPresent_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Absent;
            var optionalB = Optional<RefType>.Present(MinusFifteenIdRefType);

            var actual = Optional.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsAbsent_ExpectFalse()
        {
            var optionalA = Optional<StructType>.Present(default);
            var optionalB = Optional<StructType>.Absent;

            var actual = Optional.Same(optionalA, optionalB);
            Assert.False(actual);
        }

        [Test]
        public void Same_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectFalse()
        {
            var optionalA = Optional<RefType>.Present(PlusFifteenIdRefType);
            var optionalB = Optional<RefType>.Present(ZeroIdRefType);

            var actual = Optional.Same(optionalA, optionalB);
            Assert.False(actual);
        }
    }
}
