using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalLinqExtensionsTest
    {
        [Test]
        public void FirstOrAbsent_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrAbsent());
            Assert.AreEqual("source", ex!.ParamName);
        }

        [Test]
        public void FirstOrAbsent_ReadOnlyListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateReadOnlyList<RefType>();

            var actual = source.FirstOrAbsent();
            var expected = Optional<RefType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void FirstOrAbsent_ReadOnlyListSourceIsNotEmpty_ExpectPresentFirstItem(
            object? firstItem)
        {
            var source = CreateReadOnlyList(firstItem, new object(), new { Value = SomeString });

            var actual = source.FirstOrAbsent();
            var expected = Optional<object?>.Present(firstItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrAbsent(_ => true));
            Assert.AreEqual("source", ex!.ParamName);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateReadOnlyList(SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrAbsent(null!));
            Assert.AreEqual("predicate", ex!.ParamName);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

            var actual = source.FirstOrAbsent(_ => false);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ReadOnlyListPredicateResultIsNotAlreadyFalse_ExpectPresentFirstSuccessful()
        {
            var expectedId = 171;
            var expectedValue = new RefType
            {
                Id = expectedId
            };

            var otherRefType = new RefType
            {
                Id = expectedId
            };
            var source = CreateReadOnlyList<RefType?>(PlusFifteenIdRefType, expectedValue, MinusFifteenIdRefType, null, otherRefType);

            var actual = source.FirstOrAbsent(item => item?.Id == expectedId);
            var expected = Optional<RefType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FirstOrAbsentByPredicate_ReadOnlyListPredicateResultIsNotAlreadyFalse_ExpectCallPredicate()
        {
            var expectedValue = new RefType
            {
                Id = 171
            };
            var source = CreateReadOnlyList<RefType?>(PlusFifteenIdRefType, null, expectedValue, MinusFifteenIdRefType, expectedValue);
            var mockPredicate = CreateMockPredicate<RefType?>(item => item == expectedValue);

            var actual = source.FirstOrAbsent(mockPredicate.Object.Invoke);
            _ = Optional<RefType?>.Present(expectedValue);

            mockPredicate.Verify(p => p.Invoke(It.IsAny<RefType>()), Times.Exactly(3));
        }
    }
}