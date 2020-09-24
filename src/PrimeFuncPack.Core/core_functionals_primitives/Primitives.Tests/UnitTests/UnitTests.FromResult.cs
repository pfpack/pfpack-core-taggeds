#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest.Data;
using System;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void FromResult_ExpectUnitValue(
            bool isResultNull)
        {
            var result = isResultNull ? null : DataGenerator.GenerateRefType();
            var actual = Unit.FromResult(result);

            Assert.AreEqual(Unit.Value, actual);
        }
    }
}
