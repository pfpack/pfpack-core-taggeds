#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Objects.Tests.TestData;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
{
    public sealed partial class ObjectPredicatesTests
    {
        [Test]
        public void IsNotNull_ValueIsNull_ExpectFalse()
        {
            RefType source = null!;

            var actual = ObjectPredicates.IsNotNull(source);
            Assert.False(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.NotNullValueTestSource))]
        public void IsNotNull_ValueIsNotNull_ExpectTrue(
            in object source)
        {
            var actual = ObjectPredicates.IsNotNull(source);
            Assert.True(actual);
        }
    }
}
