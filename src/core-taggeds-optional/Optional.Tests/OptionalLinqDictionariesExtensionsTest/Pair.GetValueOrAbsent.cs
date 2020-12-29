#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalLinqDictionariesExtensionsTest
    {
        [Test]
        public void GetValueOrAbsent_PairsAreNull_ExpectArgumentNullException()
        {
            IEnumerable<KeyValuePair<int, StructType>> sourcePairs = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePairs.GetValueOrAbsent(PlusFifteen));
            Assert.AreEqual("pairs", ex.ParamName);
        }

        [Test]
        public void GetValueOrAbsent_PairsDoNotContainKey_ExpectAbsent()
        {
            var sourcePairs = CreatePairsCollection(
                new KeyValuePair<int, RefType?>(MinusFifteen, ZeroIdRefType),
                new KeyValuePair<int, RefType?>(Zero, null),
                new KeyValuePair<int, RefType?>(int.MaxValue, PlusFifteenIdRefType));

            var actual = sourcePairs.GetValueOrAbsent(PlusFifteen);
            var expected = Optional<RefType?>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetValueOrAbsent_PairsContainOnlyOneKey_ExpectPresentKeyValue(
            object? expectedValue)
        {
            var sourceKey = "Some Key";

            var sourcePairs = CreatePairsCollection(
                new KeyValuePair<string?, object?>(null, ZeroIdRefType),
                new KeyValuePair<string?, object?>(SomeString, PlusFifteenIdRefType),
                new KeyValuePair<string?, object?>(TabString, null),
                new KeyValuePair<string?, object?>(sourceKey, expectedValue),
                new KeyValuePair<string?, object?>(SomeString, MinusFifteenIdRefType));

            var actual = sourcePairs.GetValueOrAbsent(sourceKey);
            var expected = Optional<object?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void GetValueOrAbsent_PairsContainOnlyOneKeyAndKeyIsNull_ExpectPresentKeyValue()
        {
            var expectedValue = SomeTextStructType;

            var sourcePairs = CreatePairsCollection(
                new KeyValuePair<RefType?, StructType>(PlusFifteenIdRefType, NullTextStructType),
                new KeyValuePair<RefType?, StructType>(null, expectedValue));

            var actual = sourcePairs.GetValueOrAbsent(null);
            var expected = Optional<StructType>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        public void GetValueOrAbsent_PairsContainMoreThanOneKey_ExpectInvalidOperationException()
        {
            var expectedValue = SomeTextStructType;

            var sourcePairs = CreatePairsCollection(
                new KeyValuePair<RefType, StructType>(PlusFifteenIdRefType, NullTextStructType),
                new KeyValuePair<RefType, StructType>(MinusFifteenIdRefType, SomeTextStructType),
                new KeyValuePair<RefType, StructType>(PlusFifteenIdRefType, SomeTextStructType));

            _ = Assert.Throws<InvalidOperationException>(() => _ = sourcePairs.GetValueOrAbsent(PlusFifteenIdRefType));
        }
    }
}
