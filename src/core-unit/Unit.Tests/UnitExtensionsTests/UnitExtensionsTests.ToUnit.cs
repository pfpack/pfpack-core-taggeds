#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitExtensionsTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ToUnit_ExpectUnitValue(
            bool isSourceNull)
        {
            StructType? source = isSourceNull ? null : SomeTextStructType;
            var actual = source.ToUnit();

            Assert.AreEqual(Unit.Value, actual);
        }
    }
}
