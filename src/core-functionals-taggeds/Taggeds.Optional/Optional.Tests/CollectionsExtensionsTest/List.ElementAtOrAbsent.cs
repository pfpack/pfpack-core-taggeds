#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class CollectionsExtensionsTest
    {
        [Test]
        public void ElementAtOrAbsentByInt_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<RefType> source = null!;
            int index = 1;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ElementAtOrAbsentByInt_ListIndexIsInRange_ExpectPresentItem(
            int index)
        {
            var source = CreateList<StructType?>(SomeTextStructType, null, NullTextStructType);
            var actual = source.ElementAtOrAbsent(index);

            var expectedValue = source.ElementAt(index);
            var expected = Optional<StructType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(int.MaxValue)]
        public void ElementAtOrAbsentByInt_ListIndexIsNotInRange_ExpectAbsent(
            int index)
        {
            var source = CreateList(SomeTextStructType, default);

            var actual = source.ElementAtOrAbsent(index);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ElementAtOrAbsentByLong_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;
            long index = 1;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ElementAtOrAbsentByLong_ListIndexIsInRange_ExpectPresentItem(
            int index)
        {
            var source = CreateList(NullTextStructType, SomeTextStructType, SomeTextStructType);
            var actual = source.ElementAtOrAbsent(index);

            var expectedValue = source.ElementAt(index);
            var expected = Optional<StructType>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(long.MinValue)]
        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(long.MaxValue)]
        public void ElementAtOrAbsentByLong_ListIndexIsNotInRange_ExpectAbsent(
            long index)
        {
            var source = CreateList<RefType?>(PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType, null);

            var actual = source.ElementAtOrAbsent(index);
            var expected = Optional<RefType?>.Absent;

            Assert.AreEqual(expected, actual);
        }
    }
}
