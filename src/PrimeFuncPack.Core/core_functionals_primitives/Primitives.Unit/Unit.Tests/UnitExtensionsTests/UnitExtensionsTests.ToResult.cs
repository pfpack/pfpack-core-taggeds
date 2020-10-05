#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitExtensionsTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ToResult_ExpectResultValue(
            bool isResultNull)
        {
            var result = isResultNull ? null : PlusFifteenIdRefType;
            var source = Unit.Value;

            var actual = source.ToResult(result);
            Assert.AreSame(result, actual);
        }
    }
}
