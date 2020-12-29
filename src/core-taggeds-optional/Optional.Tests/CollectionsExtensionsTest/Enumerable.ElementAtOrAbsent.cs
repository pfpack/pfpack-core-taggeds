#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class CollectionsExtensionsTest
    {
        [Test]
        public void ElementAtOrAbsentByInt_CollectionSourceIsNull_ExpectArgumentNullException()
        {
            IEnumerable<StructType> source = null!;
            int index = 1;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ElementAtOrAbsentByInt_CollectionIndexIsInRange_ExpectPresentItem(
            int index)
        {
            var source = CreateCollection<RefType?>(PlusFifteenIdRefType, null, ZeroIdRefType);
            var actual = source.ElementAtOrAbsent(index);

            var expectedValue = source.ElementAt(index);
            var expected = Optional<RefType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(int.MaxValue)]
        public void ElementAtOrAbsentByInt_CollectionIndexIsNotInRange_ExpectAbsent(
            int index)
        {
            var source = CreateCollection(NullTextStructType, SomeTextStructType, default);

            var actual = source.ElementAtOrAbsent(index);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ElementAtOrAbsentByLong_CollectionSourceIsNull_ExpectArgumentNullException()
        {
            IEnumerable<StructType> source = null!;
            long index = 1;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ElementAtOrAbsentByLong_CollectionIndexIsInRange_ExpectPresentItem(
            int index)
        {
            var source = CreateCollection<StructType?>(SomeTextStructType, NullTextStructType, null);
            var actual = source.ElementAtOrAbsent(index);

            var expectedValue = source.ElementAt(index);
            var expected = Optional<StructType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(long.MinValue)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(long.MaxValue)]
        public void ElementAtOrAbsentByLong_CollectionIndexIsNotInRange_ExpectAbsent(
            long index)
        {
            var source = CreateCollection(PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType);

            var actual = source.ElementAtOrAbsent(index);
            var expected = Optional<RefType>.Absent;

            Assert.AreEqual(expected, actual);
        }
    }
}
