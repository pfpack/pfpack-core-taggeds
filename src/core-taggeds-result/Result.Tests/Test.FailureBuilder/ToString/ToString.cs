#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class FailureBuilderTest
    {
        [Test]
        public void ToString_SourceFailureToStringReturnsNull_ExpectEmpty()
        {
            var sourceFailure = new StubToStringStructType(null);
            var builder = Result.Failure(sourceFailure);

            var actual = builder.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToString_SourceFailureToStringReturnsNotNull_ExpectResultOfSourceFailureToString(
            string resultOfFailureToString)
        {
            var sourceFailure = new StubToStringStructType(resultOfFailureToString);
            var builder = Result.Failure(sourceFailure);

            var actual = builder.ToString();
            Assert.AreEqual(resultOfFailureToString, actual);
        }
    }
}