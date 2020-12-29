#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    partial class DictionariesExtensionsTest
    {
        [Test]
        public void GetValueOrAbsent_DictionaryPairsAreNull_ExpectArgumentNullException()
        {
            IDictionary<string, StructType> sourceDictionary = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourceDictionary.GetValueOrAbsent(SomeString));
            Assert.AreEqual("pairs", ex.ParamName);
        }

        [Test]
        public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsFalse_ExpectAbsent()
        {
            var sourceDictionary = CreateMockDictionary<RefType?, int>(false, PlusFifteen).Object;

            var actual = sourceDictionary.GetValueOrAbsent(PlusFifteenIdRefType);
            var expected = Optional<int>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsTrue_ExpectPresent(
            object? expectedValue)
        {
            var sourceDictionary = CreateMockDictionary<StructType, object?>(true, expectedValue).Object;

            var actual = sourceDictionary.GetValueOrAbsent(NullTextStructType);
            var expected = Optional<object?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsTrueAndKeyIsNull_ExpectPresent()
        {
            var expectedValue = SomeTextStructType;
            var sourceDictionary = CreateMockDictionary<object?, StructType>(true, expectedValue).Object;

            var actual = sourceDictionary.GetValueOrAbsent(null);
            var expected = Optional<StructType>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }
    }
}