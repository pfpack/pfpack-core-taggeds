#nullable enable

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
        public void SingleOrAbsent_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent());
            Assert.AreEqual("source", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsent_ListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateList<StructType>();

            var actual = source.SingleOrAbsent();
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void SingleOrAbsent_ListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
            object? singleItem)
        {
            var source = CreateList(singleItem);

            var actual = source.SingleOrAbsent();
            var expected = Optional<object?>.Present(singleItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsent_ListSourceContainsMoreThanOneElement_ExpectInvalidOperationException()
        {
            var source = CreateList(PlusFifteenIdRefType, MinusFifteenIdRefType);
            _ = Assert.Throws<InvalidOperationException>(() => _ = source.SingleOrAbsent());
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(CreateSomeException));
            Assert.AreEqual("source", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ListExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = CreateList(PlusFifteenIdRefType);
            Func<Exception> exceptionFactory = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(exceptionFactory));
            Assert.AreEqual("moreThanOneElementExceptionFactory", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ListSourceIsEmpty_ExpectAbsent()
        {
            var source = CreateList<StructType>();

            var actual = source.SingleOrAbsent(CreateSomeException);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void SingleOrAbsentWithExceptionFactory_ListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
            object? singleItem)
        {
            var source = CreateList(singleItem);

            var actual = source.SingleOrAbsent(CreateSomeException);
            var expected = Optional<object?>.Present(singleItem);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentWithExceptionFactory_ListSourceContainsMoreThanOneElement_ExpectCreatedException()
        {
            var source = CreateList(PlusFifteenIdRefType, MinusFifteenIdRefType);
            var createdException = new SomeException();

            var ex = Assert.Throws<SomeException>(() => _ = source.SingleOrAbsent(() => createdException));
            Assert.AreSame(createdException, ex);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(_ => false));
            Assert.AreEqual("source", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateList(MinusFifteenIdRefType);
            Func<RefType, bool> predicate = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(predicate));
            Assert.AreEqual("predicate", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateList(SomeTextStructType, NullTextStructType);

            var actual = source.SingleOrAbsent(_ => false);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
        {
            var expectedText = "Expected Text";
            var expectedValue = new StructType
            {
                Text = expectedText
            };

            var source = CreateList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

            var actual = source.SingleOrAbsent(item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));
            var expected = Optional<StructType?>.Present(expectedValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicate_ListPredicateResultIsTrueMoreThanOneTime_ExpectInvalidOperationException()
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
            var source = CreateList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

            var mockPredicate = CreateMockPredicate<StructType?>(
                item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));

            _ = Assert.Throws<InvalidOperationException>(() => _ = source.SingleOrAbsent(mockPredicate.Object.Invoke));
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ListSourceIsNull_ExpectArgumentNullException()
        {
            IList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(
                _ => false, CreateSomeException));

            Assert.AreEqual("source", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ListPredicateIsNull_ExpectArgumentNullException()
        {
            var source = CreateList(MinusFifteenIdRefType);
            Func<RefType, bool> predicate = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(predicate, CreateSomeException));
            Assert.AreEqual("predicate", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ListExceptionFactoryIsNull_ExpectArgumentNullException()
        {
            var source = CreateList(MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = source.SingleOrAbsent(_ => false, null!));
            Assert.AreEqual("moreThanOneMatchExceptionFactory", ex!.ParamName);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
        {
            var source = CreateList(SomeTextStructType, NullTextStructType);

            var actual = source.SingleOrAbsent(_ => false, CreateSomeException);
            var expected = Optional<StructType>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
        {
            var expectedText = "Expected Text";
            var expectedValue = new StructType
            {
                Text = expectedText
            };

            var source = CreateList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

            var actual = source.SingleOrAbsent(
                item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase),
                CreateSomeException);

            var expected = Optional<StructType?>.Present(expectedValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SingleOrAbsentByPredicateAndFactory_ListPredicateResultIsTrueMoreThanOneTime_ExpectCreatedException()
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
            var source = CreateList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

            var mockPredicate = CreateMockPredicate<StructType?>(
                item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));

            var createdException = new SomeException();
            var actualException = Assert.Throws<SomeException>(() => _ = source.SingleOrAbsent(
                mockPredicate.Object.Invoke, () => createdException));

            Assert.AreSame(createdException, actualException);
        }
    }
}