using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class SuccessBuilderTest
    {
        [Test]
        public void ToString_SourceSuccessIsNull_ExpectEmpty()
        {
            var builder = Result.Success<RefType?>(null);

            var actual = builder.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceSuccessToStringReturnsNull_ExpectEmpty()
        {
            var sourceSuccess = new StubToStringRefType(null);
            var builder = Result.Success(sourceSuccess);

            var actual = builder.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToString_SourceSuccessToStringReturnsNotNull_ExpectResultOfSourceSuccessToString(
            string resultOfSuccessToString)
        {
            var sourceSuccess = new StubToStringRefType(resultOfSuccessToString);
            var builder = Result.Success(sourceSuccess);

            var actual = builder.ToString();
            Assert.AreEqual(resultOfSuccessToString, actual);
        }
    }
}