#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class CollectionsExtensionsTest
    {
        [Test]
        public void LastOrAbsent_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<RefType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.LastOrAbsent());
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void LastOrAbsent_ListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateList<StructType>();

            var actual = source.LastOrAbsent();
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void LastOrAbsent_ListSourceIsNotEmpty_ExpectPresentLastItem(
            in object? lastItem)
        {
            var source = CreateList(new object(), new { Value = SomeString }, lastItem);

            var actual = source.LastOrAbsent();
            var expected = Optional<object?>.Present(lastItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LastOrAbsentByPredicate_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.LastOrAbsent(_ => true));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void LastOrAbsentByPredicate_ListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateList(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.LastOrAbsent(null!));
            Assert.AreEqual("predicate", ex.ParamName);
        }

        [Test]
        public void LastOrAbsentByPredicate_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateList(SomeTextStructType, NullTextStructType);

            var actual = source.LastOrAbsent(_ => false);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LastOrAbsentByPredicate_ListPredicateResultIsNotAlreadyFalse_ExpectPresentLastSuccessful()
        {
            var expectedId = 75;
            var expectedValue = new RefType
            {
                Id = expectedId
            };

            var otherRefType = new RefType
            {
                Id = expectedId
            };
            var source = CreateList<RefType?>(
                PlusFifteenIdRefType, otherRefType, MinusFifteenIdRefType, null, expectedValue, ZeroIdRefType);

            var actual = source.LastOrAbsent(item => item?.Id == expectedId);
            var expected = Optional<RefType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LastOrAbsentByPredicate_ListPredicateResultIsNotAlreadyFalse_ExpectCallPredicate()
        {
            var expectedValue = new RefType
            {
                Id = 21
            };
            var source = CreateList<RefType?>(
                expectedValue, ZeroIdRefType, PlusFifteenIdRefType, expectedValue, null, MinusFifteenIdRefType);
            var mockPredicate = CreateMockPredicate<RefType?>(item => item == expectedValue);

            var actual = source.LastOrAbsent(mockPredicate.Object.Invoke);
            _ = Optional<RefType?>.Present(expectedValue);

            mockPredicate.Verify(p => p.Invoke(It.IsAny<RefType?>()), Times.Exactly(3));
        }
    }
}