#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest.Data;
using System;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitExtensionsTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ToUnit_ExpectUnitValue(
            bool isSourceNull)
        {
            StructType? source = isSourceNull ? null : DataGenerator.GenerateStructType();
            var actual = source.ToUnit();

            Assert.AreEqual(Unit.Value, actual);
        }
    }
}
