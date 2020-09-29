#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

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
            var result = isResultNull ? null : MinusFifteenIdRefType;
            var actual = Unit.FromResult(result);

            Assert.AreEqual(Unit.Value, actual);
        }
    }
}
