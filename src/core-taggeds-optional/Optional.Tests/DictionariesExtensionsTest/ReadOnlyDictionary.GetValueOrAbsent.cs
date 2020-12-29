#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class DictionariesExtensionsTest
    {
        [Test]
        public void GetValueOrAbsent_ReadOnlyDictionaryPairsAreNull_ExpectArgumentNullException()
        {
            IReadOnlyDictionary<int, StructType> sourceDictionary = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourceDictionary.GetValueOrAbsent(PlusFifteen));
            Assert.AreEqual("dictionary", ex.ParamName);
        }

        [Test]
        public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsFalse_ExpectAbsent()
        {
            var sourceDictionary = CreateMockReadOnlyDictionary<int, RefType>(false, PlusFifteenIdRefType).Object;

            var actual = sourceDictionary.GetValueOrAbsent(MinusFifteen);
            var expected = Optional<RefType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsTrue_ExpectPresent()
        {
            var expectedValue = SomeTextStructType;
            var sourceDictionary = CreateMockReadOnlyDictionary<int, StructType>(true, expectedValue).Object;

            var actual = sourceDictionary.GetValueOrAbsent(PlusFifteen);
            var expected = Optional<StructType>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsTrueAndKeyIsNull_ExpectPresent(
            object? expectedValue)
        {
            var sourceDictionary = CreateMockReadOnlyDictionary<string?, object?>(true, expectedValue).Object;

            var actual = sourceDictionary.GetValueOrAbsent(null);
            var expected = Optional<object?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }
    }
}
