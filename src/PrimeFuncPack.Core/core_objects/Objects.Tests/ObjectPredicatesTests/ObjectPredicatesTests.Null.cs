#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Objects.Tests.TestData;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
{
    partial class ObjectPredicatesTests
    {
        [Test]
        public void IsNull_ValueIsNull_ExpectTrue()
        {
            RefType source = null!;

            var actual = ObjectPredicates.IsNull(source);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.NotNullValueTestSource))]
        public void IsNull_ValueIsNotNull_ExpectFalse(
            in object source)
        {
            var actual = ObjectPredicates.IsNull(source);
            Assert.False(actual);
        }
    }
}
