using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class SuccessBuilderTest
    {
        [Test]
        public void Equality_LeftIsDefaultAndRightIsDefault_ExpectTrue()
        {
            var left = default(SuccessBuilder<RefType>);
            var right = new SuccessBuilder<RefType>();

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftIsDefaultAndRightSuccessIsNull_ExpectTrue()
        {
            var left = default(SuccessBuilder<SomeRecord?>);
            var right = Result.Success<SomeRecord?>(null);

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftSuccessIsDefaultAndRightIsDefault_ExpectTrue()
        {
            var left = Result.Success<StructType>(new());
            var right = new SuccessBuilder<StructType>();

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftSuccessIsDefaultAndRightSuccessIsDefault_ExpectTrue()
        {
            var left = Result.Success<SomeRecord?>(null);
            var right = Result.Success<SomeRecord?>(null);

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftSuccessIsEqualRightSuccess_ExpectTrue()
        {
            var text = "Some property string value";

            var leftSuccess = new SomeRecord
            {
                Text = text
            };
            var left = Result.Success(leftSuccess);

            var rightSuccess = new SomeRecord
            {
                Text = text
            };
            var right = Result.Success(rightSuccess);

            var actual = left == right;
            Assert.True(actual);
        }

        [Test]
        public void Equality_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
        {
            var left = new SuccessBuilder<object>();
            var right = Result.Success<object>(new());

            var actual = left == right;
            Assert.False(actual);
        }

        [Test]
        public void Equality_LeftSuccessIsNotEqualToRightSuccess_ExpectFalse()
        {
            var leftSuccess = new RefType();
            var left = Result.Success(leftSuccess);

            var rightSuccess = new RefType();
            var right = Result.Success(rightSuccess);

            var actual = left == right;
            Assert.False(actual);
        }
    }
}