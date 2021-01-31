#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedUnionResultExtensions
    {
        [Test]
        public void ToResult_SourceUnionIsDefault_ExpectDefaultResult()
        {
            var sourceUnion = default(TaggedUnion<SomeRecord, StructType>);

            var actual = sourceUnion.ToResult();
            var expected = default(Result<SomeRecord, StructType>);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToResult_SourceUnionIsSecond_ExpectFailureResult()
        {
            var sourceValue = new SomeError(MinusFifteen);
            var sourceUnion = TaggedUnion<RefType?, SomeError>.Second(sourceValue);

            var actual = sourceUnion.ToResult();
            var expected = new Result<RefType?, SomeError>(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToResult_SourceUnionIsFirstAndSourceValueIsNull_ExpectSuccessResultOfNullValue()
        {
            var sourceUnion = TaggedUnion<RefType?, StructType>.First(null);

            var actual = sourceUnion.ToResult();
            var expected = new Result<RefType?, StructType>(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToResult_SourceUnionIsFirstAndSourceValueIsNotNull_ExpectSuccessResultOfSourceValue()
        {
            var sourceValue = new SomeRecord
            {
                Text = SomeString
            };
            var sourceUnion = TaggedUnion<SomeRecord, SomeError>.First(sourceValue);

            var actual = sourceUnion.ToResult();
            var expected = new Result<SomeRecord, SomeError>(sourceValue);

            Assert.AreEqual(expected, actual);
        }
    }
}