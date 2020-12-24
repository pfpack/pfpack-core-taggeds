#nullable enable

using Moq;
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
        public void FirstOrAbsent_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrAbsent());
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void FirstOrAbsent_ListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateList<StructType?>();

            var actual = source.FirstOrAbsent();
            var expected = Optional<StructType?>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void FirstOrAbsent_ListSourceIsNotEmpty_ExpectPresentFirstItem(
            object? firstItem)
        {
            var source = CreateList(firstItem, new object(), new { Value = SomeString });

            var actual = source.FirstOrAbsent();
            var expected = Optional<object?>.Present(firstItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrAbsent(_ => true));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateList(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrAbsent(null!));
            Assert.AreEqual("predicate", ex.ParamName);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateList<RefType?>(PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType, null);

            var actual = source.FirstOrAbsent(_ => false);
            var expected = Optional<RefType?>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ListPredicateResultIsNotAlreadyFalse_ExpectPresentFirstSuccessful()
        {
            var expectedId = 1015;
            var expectedValue = new RefType
            {
                Id = expectedId
            };

            var otherRefType = new RefType
            {
                Id = expectedId
            };
            var source = CreateList<RefType?>(PlusFifteenIdRefType, expectedValue, MinusFifteenIdRefType, null, otherRefType);

            var actual = source.FirstOrAbsent(item => item?.Id == expectedId);
            var expected = Optional<RefType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ListPredicateResultIsNotAlreadyFalse_ExpectCallPredicate()
        {
            var expectedValue = new RefType
            {
                Id = -715
            };
            var source = CreateList<RefType?>(PlusFifteenIdRefType, null, expectedValue, MinusFifteenIdRefType, expectedValue);
            var mockPredicate = CreateMockPredicate<RefType?>(item => item == expectedValue);

            var actual = source.FirstOrAbsent(mockPredicate.Object.Invoke);
            _ = Optional<RefType?>.Present(expectedValue);

            mockPredicate.Verify(p => p.Invoke(It.IsAny<RefType>()), Times.Exactly(3));
        }
    }
}