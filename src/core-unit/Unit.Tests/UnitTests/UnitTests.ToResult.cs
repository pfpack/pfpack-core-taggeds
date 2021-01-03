#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ToResult_ExpectResultValue(
            bool isResultNull)
        {
            StructType? result = isResultNull ? null : SomeTextStructType;
            var source = Unit.Value;

            var actual = Unit.ToResult(source, result);
            Assert.AreEqual(result, actual);
        }
    }
}
