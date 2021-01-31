#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultStaticTest
    {
        [Test]
        public void Present_SourceValueIsNullForgivenRef_ExpectIsSuccessReturnsTrue()
        {
            var actual = Result.Present<SomeRecord>(null!);
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void Present_SourceValueIsNullForgivenRef_ExpectIsFailureReturnsFalse()
        {
            var actual = Result.Present<SomeRecord>(null!);
            Assert.False(actual.IsFailure);
        }

        [Test]
        public void Present_SourceValueIsNullableRef_ExpectIsSuccessReturnsTrue()
        {
            var actual = Result.Present<SomeRecord?>(null);
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void Present_SourceValueIsNullableRef_ExpectIsFailureReturnsFalse()
        {
            var actual = Result.Present<SomeRecord?>(null);
            Assert.False(actual.IsFailure);
        }

        [Test]
        public void Present_SourceValueIsNullableStruct_ExpectIsSuccessReturnsTrue()
        {
            var actual = Result.Present<StructType?>(null);
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void Present_SourceValueIsNullableStruct_ExpectIsFailureReturnsFalse()
        {
            var actual = Result.Present<StructType?>(null);
            Assert.False(actual.IsFailure);
        }

        [Test]
        public void Present_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
        {
            var actual = Result.Present<StructType>(default);
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void Present_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
        {
            var actual = Result.Present(ZeroIdRefType);
            Assert.False(actual.IsFailure);
        }
    }
}