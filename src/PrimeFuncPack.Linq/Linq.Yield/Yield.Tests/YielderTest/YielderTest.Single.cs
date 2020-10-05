#nullable enable

using NUnit.Framework;
using System.Linq;

namespace PrimeFuncPack.Linq.Yield.Tests
{
    partial class YielderTest
    {
        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.NullableObjectTestSource))]
        public void YieldSingle_ExpectCollectionLengthEqualsOne(
            in object? sourceValue)
        {
            var actual = Yielder.YieldSingle(sourceValue);

            var actualLength = actual.Count();
            Assert.AreEqual(1, actualLength);
        }

        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.NullableObjectTestSource))]
        public void YieldSingle_ExpectFirstItemIsSameAsSourceValue(
            in object? sourceValue)
        {
            var actual = Yielder.YieldSingle(sourceValue);

            var actualFirst = actual.FirstOrDefault();
            Assert.AreSame(sourceValue, actualFirst);
        }
    }
}
