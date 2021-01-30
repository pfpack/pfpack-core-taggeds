#nullable enable

using NUnit.Framework;
using System.Linq;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class YieldExtensionsTest
    {
        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.NullableObjectTestSource))]
        public void YieldSingle_ExpectCollectionLengthEqualsOne(
            in object? sourceValue)
        {
            var actual = sourceValue.YieldSingle();

            var actualLength = actual.Count();
            Assert.AreEqual(1, actualLength);
        }

        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.NullableObjectTestSource))]
        public void YieldSingle_ExpectFirstItemIsSameAsSourceValue(
            in object? sourceValue)
        {
            var actual = sourceValue.YieldSingle();

            var actualFirst = actual.FirstOrDefault();
            Assert.AreSame(sourceValue, actualFirst);
        }
    }
}
