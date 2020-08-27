#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Infrastructure.Tests.Stubs;
using System;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxTests
    {
        [Test]
        public void Equality_AIsNullAndBIsNull_ExpectTrue()
        {
            Box<RefType>? boxA = null!;
            Box<RefType>? boxB = null!;

            var actual = (boxA == boxB);
            Assert.True(actual);
        }

        [Test]
        public void Equality_AIsNullAndBIsNotNull_ExpectFalse()
        {
            Box<int?>? boxA = new Box<int?>(null);
            Box<int?>? boxB = null!;

            var actual = (boxA == boxB);
            Assert.False(actual);
        }

        [Test]
        public void Equality_AIsNotNullAndBIsNull_ExpectFalse()
        {
            Box<RefType>? boxA = null!;
            Box<RefType>? boxB = new Box<RefType>(new RefType());

            var actual = (boxA == boxB);
            Assert.False(actual);
        }

        [Test]
        public void Equality_AIsSameAsB_ExpectTrue()
        {
            var value = new StructType
            {
                Text = GenerateText()
            };
            var boxA = new Box<StructType>(value);
            var boxB = boxA;

            var actual = (boxA == boxB);
            Assert.True(actual);
        }

        [Test]
        public void Equality_ValueAEqualsValueB_ExpectTrue()
        {
            var text = GenerateText();

            var a = new StructType
            {
                Text = text
            };
            var boxA = new Box<StructType>(a);

            var b = new StructType
            {
                Text = text
            };
            var boxB = new Box<StructType>(b);

            var actual = (boxA == boxB);
            Assert.True(actual);
        }

        [Test]
        public void Equality_ValueAIsNotEqualValueB_ExpectFalse()
        {
            var id = GenerateInteger();

            var a = new RefType
            {
                Id = id
            };
            var boxA = new Box<RefType>(a);

            var b = new RefType
            {
                Id = id
            };
            var boxB = new Box<RefType>(b);

            var actual = (boxA == boxB);
            Assert.False(actual);
        }

        [Test]
        public void Equality_ValueAAndValueBAreNull_ExpectTrue()
        {
            var boxA = new Box<StubType?>(null);
            var boxB = new Box<StubType?>(null);

            var actual = (boxA == boxB);
            Assert.True(actual);
        }

        [Test]
        public void Equality_ValueAIsNullAndValueBIsNotNull_ExpectFalse()
        {
            var boxA = new Box<RefType>(null!);

            var b = new RefType
            {
                Id = GenerateInteger()
            };
            var boxB = new Box<RefType>(b);

            var actual = (boxA == boxB);
            Assert.False(actual);
        }

        [Test]
        public void Equality_ValueAIsNotNullAndValueBIsNull_ExpectFalse()
        {
            var a = new RefType
            {
                Id = GenerateInteger()
            };

            var boxA = new Box<RefType?>(a);
            var boxB = new Box<RefType?>(null);

            var actual = (boxA == boxB);
            Assert.False(actual);
        }

        //

        [Test]
        public void Inequality_AIsNullAndBIsNull_ExpectFalse()
        {
            Box<RefType>? boxA = null!;
            Box<RefType>? boxB = null!;

            var actual = (boxA != boxB);
            Assert.False(actual);
        }

        [Test]
        public void Inequality_AIsNullAndBIsNotNull_ExpectTrue()
        {
            Box<int?>? boxA = new Box<int?>(null);
            Box<int?>? boxB = null!;

            var actual = (boxA != boxB);
            Assert.True(actual);
        }

        [Test]
        public void Inequality_AIsNotNullAndBIsNull_ExpectTrue()
        {
            Box<RefType>? boxA = null!;
            Box<RefType>? boxB = new Box<RefType>(new RefType());

            var actual = (boxA != boxB);
            Assert.True(actual);
        }

        [Test]
        public void Inequality_AIsSameAsB_ExpectFalse()
        {
            var value = new StructType
            {
                Text = GenerateText()
            };
            var boxA = new Box<StructType>(value);
            var boxB = boxA;

            var actual = (boxA != boxB);
            Assert.False(actual);
        }

        [Test]
        public void Inequality_ValueAEqualsValueB_ExpectFalse()
        {
            var text = GenerateText();

            var a = new StructType
            {
                Text = text
            };
            var boxA = new Box<StructType>(a);

            var b = new StructType
            {
                Text = text
            };
            var boxB = new Box<StructType>(b);

            var actual = (boxA != boxB);
            Assert.False(actual);
        }

        [Test]
        public void Inequality_ValueAIsNotEqualValueB_ExpectTrue()
        {
            var id = GenerateInteger();

            var a = new RefType
            {
                Id = id
            };
            var boxA = new Box<RefType>(a);

            var b = new RefType
            {
                Id = id
            };
            var boxB = new Box<RefType>(b);

            var actual = (boxA != boxB);
            Assert.True(actual);
        }

        [Test]
        public void Inequality_ValueAAndValueBAreNull_ExpectFalse()
        {
            var boxA = new Box<StubType?>(null);
            var boxB = new Box<StubType?>(null);

            var actual = (boxA != boxB);
            Assert.False(actual);
        }

        [Test]
        public void Inequality_ValueAIsNullAndValueBIsNotNull_ExpectTrue()
        {
            var boxA = new Box<RefType>(null!);

            var b = new RefType
            {
                Id = GenerateInteger()
            };
            var boxB = new Box<RefType>(b);

            var actual = (boxA != boxB);
            Assert.True(actual);
        }

        [Test]
        public void Inequality_ValueAIsNotNullAndValueBIsNull_ExpectTrue()
        {
            var a = new RefType
            {
                Id = GenerateInteger()
            };

            var boxA = new Box<RefType?>(a);
            var boxB = new Box<RefType?>(null);

            var actual = (boxA != boxB);
            Assert.True(actual);
        }
    }
}
