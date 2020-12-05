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
        public void LastOrAbsent_CollectionSourceIsNull_ExpectArgumentNullException()
        {
            IEnumerable<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.LastOrAbsent());
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void LastOrAbsent_CollectionSourceIsEmpty_ExpectAbsent()
        {
            var source = Enumerable.Empty<RefType>();

            var actual = source.LastOrAbsent();
            var expected = Optional<RefType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void LastOrAbsent_CollectionSourceIsNotEmpty_ExpectPresentLastItem(
            in object? lastItem)
        {
            var source = CreateCollection(new object(), new { Value = SomeString }, lastItem);

            var actual = source.LastOrAbsent();
            var expected = Optional<object?>.Present(lastItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LastOrAbsentByPredicate_CollectionSourceIsNull_ExpectArgumentNullException()
        {
            IEnumerable<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.LastOrAbsent(_ => true));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void LastOrAbsentByPredicate_CollectionPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateCollection(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.LastOrAbsent(null!));
            Assert.AreEqual("predicate", ex.ParamName);
        }

        [Test]
        public void LastOrAbsentByPredicate_CollectionPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateCollection(SomeTextStructType, NullTextStructType);

            var actual = source.LastOrAbsent(_ => false);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LastOrAbsentByPredicate_CollectionPredicateResultIsNotAlreadyFalse_ExpectPresentLastSuccessful()
        {
            var expectedId = 255;
            var expectedValue = new RefType
            {
                Id = expectedId
            };

            var otherRefType = new RefType
            {
                Id = expectedId
            };
            var source = CreateCollection<RefType?>(
                PlusFifteenIdRefType, otherRefType, MinusFifteenIdRefType, null, expectedValue, ZeroIdRefType);

            var actual = source.LastOrAbsent(item => item?.Id == expectedId);
            var expected = Optional<RefType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LastOrAbsentByPredicate_CollectionPredicateResultIsNotAlreadyFalse_ExpectCallPredicate()
        {
            var expectedValue = new RefType
            {
                Id = 91
            };
            var source = CreateCollection<RefType?>(PlusFifteenIdRefType, null, expectedValue, MinusFifteenIdRefType);
            var mockPredicate = CreateMockPredicate<RefType?>(item => item == expectedValue);

            var actual = source.LastOrAbsent(mockPredicate.Object.Invoke);
            _ = Optional<RefType?>.Present(expectedValue);

            var expectedTimes = source.Count();
            mockPredicate.Verify(p => p.Invoke(It.IsAny<RefType>()), Times.Exactly(expectedTimes));
        }
    }
}
