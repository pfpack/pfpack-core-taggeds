#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Objects.Tests.TestData;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
{
    partial class ObjectPredicateExtensionsTests
    {
        [Test]
        public void IsNotNull_ValueIsNull_ExpectFalse()
        {
            RefType source = null!;

            var actual = source.IsNotNull();
            Assert.False(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.NotNullValueTestSource))]
        public void IsNotNull_ValueIsNotNull_ExpectTrue(
            in object source)
        {
            var actual = source.IsNotNull();
            Assert.True(actual);
        }
    }
}
