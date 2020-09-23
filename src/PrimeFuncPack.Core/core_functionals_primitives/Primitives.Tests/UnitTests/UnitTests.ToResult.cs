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
        public void ToResult_ExpectResultValue(
            bool isResultNull)
        {
            StructType? result = isResultNull ? null : DataGenerator.GenerateStructType();
            var source = Unit.Value;

            var actual = Unit.ToResult(source, result);
            Assert.AreEqual(result, actual);
        }
    }
}
