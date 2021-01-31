#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class SuccessBuilderTest
    {
        [Test]
        public void Inequality_LeftIsDefaultAndRightIsDefault_ExpectFalse()
        {
            var left = default(SuccessBuilder<SomeRecord?>);
            var right = new SuccessBuilder<SomeRecord?>();

            var actual = left != right;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_LeftIsDefaultAndRightSuccessIsNull_ExpectFalse()
        {
            var left = new SuccessBuilder<RefType>();
            var right = Result.Success<RefType>(null!);

            var actual = left != right;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_LeftSuccessIsDefaultAndRightIsDefault_ExpectFalse()
        {
            var left = Result.Success<DateTimeOffset>(new());
            var right = new SuccessBuilder<DateTimeOffset>();

            var actual = left != right;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_LeftSuccessIsDefaultAndRightSuccessIsDefault_ExpectFalse()
        {
            var left = Result.Success<int?>(null);
            var right = Result.Success<int?>(null);

            var actual = left != right;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_LeftSuccessIsEqualRightSuccess_ExpectFalse()
        {
            var text = "Some property string value";

            var leftSuccess = new StructType
            {
                Text = text
            };
            var left = Result.Success(leftSuccess);

            var rightSuccess = new StructType
            {
                Text = text
            };
            var right = Result.Success(rightSuccess);

            var actual = left != right;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_LeftIsDefaultAndRightIsNotDefault_ExpectTrue()
        {
            var left = new SuccessBuilder<RefType>();
            var right = Result.Success<RefType>(new());

            var actual = left != right;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_LeftSuccessIsNotEqualToRightSuccess_ExpectTrue()
        {
            var left = Result.Success<object>(new());
            var right = Result.Success<object>(new());

            var actual = left != right;
            Assert.True(actual);
        }
    }
}