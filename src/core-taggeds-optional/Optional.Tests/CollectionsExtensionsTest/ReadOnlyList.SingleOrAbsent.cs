#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    partial class CollectionsExtensionsTest
    {
        [Test]
        public void SingleOrAbsent_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent());
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsent_ReadOnlyListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateReadOnlyList<StructType>();

            var actual = source.SingleOrAbsent();
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void SingleOrAbsent_ReadOnlyListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
            object? singleItem)
        {
            var source = CreateReadOnlyList(singleItem);

            var actual = source.SingleOrAbsent();
            var expected = Optional<object?>.Present(singleItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsent_ReadOnlyListSourceContainsMoreThanOneElement_ExpectInvalidOperationException()
        {
            var source = CreateReadOnlyList(PlusFifteenIdRefType, MinusFifteenIdRefType);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.SingleOrAbsent());
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(CreateSomeException));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ReadOnlyListExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = CreateReadOnlyList(PlusFifteenIdRefType);
            Func<Exception> exceptionFactory = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(exceptionFactory));
            Assert.AreEqual("moreThanOneElementExceptionFactory", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateReadOnlyList<StructType>();

            var actual = source.SingleOrAbsent(CreateSomeException);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
            object? singleItem)
        {
            var source = CreateReadOnlyList(singleItem);

            var actual = source.SingleOrAbsent(CreateSomeException);
            var expected = Optional<object?>.Present(singleItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceContainsMoreThanOneElement_ExpectCreatedException()
        {
            var source = CreateReadOnlyList(PlusFifteenIdRefType, MinusFifteenIdRefType);
            var createdException = new SomeException();

            var ex = Assert.Throws<SomeException>(() => _ = source.SingleOrAbsent(() => createdException));
            Assert.AreSame(createdException, ex);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(_ => false));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateReadOnlyList(MinusFifteenIdRefType);
            Func<RefType, bool> predicate = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(predicate));
            Assert.AreEqual("predicate", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

            var actual = source.SingleOrAbsent(_ => false);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ReadOnlyListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
        {
            var expectedText = "Expected Text";
            var expectedValue = new StructType
            {
                Text = expectedText
            };

            var source = CreateReadOnlyList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

            var actual = source.SingleOrAbsent(item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));
            var expected = Optional<StructType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ReadOnlyListPredicateResultIsTrueMoreThanOneTime_ExpectInvalidOperationException()
        {
            var expectedText = "Expected Text";
            var expectedValue = new StructType
            {
                Text = expectedText
            };

            var expectedTextStructType = new StructType
            {
                Text = expectedText
            };
            var source = CreateReadOnlyList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

            var mockPredicate = CreateMockPredicate<StructType?>(
                item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));

            _ = Assert.Throws<InvalidOperationException>(() => _ = source.SingleOrAbsent(mockPredicate.Object.Invoke));
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(
                _ => false, CreateSomeException));

            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateReadOnlyList(MinusFifteenIdRefType);
            Func<RefType, bool> predicate = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(predicate, CreateSomeException));
            Assert.AreEqual("predicate", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = CreateReadOnlyList(MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(_ => false, null!));
            Assert.AreEqual("moreThanOneMatchExceptionFactory", ex.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

            var actual = source.SingleOrAbsent(_ => false, CreateSomeException);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
        {
            var expectedText = "Expected Text";
            var expectedValue = new StructType
            {
                Text = expectedText
            };

            var source = CreateReadOnlyList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

            var actual = source.SingleOrAbsent(
                item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase),
                CreateSomeException);

            var expected = Optional<StructType?>.Present(expectedValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateResultIsTrueMoreThanOneTime_ExpectCreatedException()
        {
            var expectedText = "Expected Text";
            var expectedValue = new StructType
            {
                Text = expectedText
            };

            var expectedTextStructType = new StructType
            {
                Text = expectedText
            };
            var source = CreateReadOnlyList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

            var mockPredicate = CreateMockPredicate<StructType?>(
                item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));

            var createdException = new SomeException();
            var actualException = Assert.Throws<SomeException>(() => _ = source.SingleOrAbsent(
                mockPredicate.Object.Invoke, () => createdException));

            Assert.AreSame(createdException, actualException);
        }
    }
}