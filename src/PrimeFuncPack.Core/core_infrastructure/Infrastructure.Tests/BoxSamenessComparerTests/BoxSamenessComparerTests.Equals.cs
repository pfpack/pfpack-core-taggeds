#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Infrastructure.Tests.Stubs;
using PrimeFuncPack.UnitTest.Data;
using System;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxSamenessComparerTests
    {
        [Test]
        public void Equals_XIsNullAndYIsNull_ExpectTrue()
        {
            Box<RefType>? boxX = null;
            Box<RefType>? boxY = null;

            var actual = BoxSamenessComparer<RefType>.Default.Equals(boxX, boxY);
            Assert.True(actual);
        }

        [Test]
        public void Equals_XIsNullAndYIsNotNull_ExpectFalse()
        {
            Box<int?>? boxX = new Box<int?>(null);
            Box<int?>? boxY = null;

            var actual = BoxSamenessComparer<int?>.Default.Equals(boxX, boxY);
            Assert.False(actual);
        }

        [Test]
        public void Equals_XIsNotNullAndYIsNull_ExpectFalse()
        {
            Box<RefType>? boxX = null;
            Box<RefType>? boxY = new Box<RefType>(new RefType());

            var actual = BoxSamenessComparer<RefType>.Default.Equals(boxX, boxY);
            Assert.False(actual);
        }

        [Test]
        public void Equals_XIsSameAsB_ExpectTrue()
        {
            var value = new StructType
            {
                Text = "Some Text"
            };
            var source = new Box<StructType>(value);

            var actual = new BoxSamenessComparer<StructType>().Equals(source, source);
            Assert.True(actual);
        }

        [Test]
        public void Equals_ValueASameValueB_ExpectFalse()
        {
            var text = "Some Text";

            var x = new StructType
            {
                Text = text
            };
            var boxX = new Box<StructType>(x);

            var y = new StructType
            {
                Text = text
            };
            var boxY = new Box<StructType>(y);

            var actual = new BoxSamenessComparer<StructType>().Equals(boxX, boxY);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ValueXIsNotEqualValueB_ExpectFalse()
        {
            var id = 21;

            var x = new RefType
            {
                Id = id
            };
            var boxX = new Box<RefType>(x);

            var y = new RefType
            {
                Id = id
            };
            var boxY = new Box<RefType>(y);

            var actual = BoxSamenessComparer<RefType>.Default.Equals(boxX, boxY);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ValueAAndValueBAreNull_ExpectFalse()
        {
            var boxX = new Box<StubType?>(null);
            var boxY = new Box<StubType?>(null);

            var actual = BoxSamenessComparer<StubType?>.Default.Equals(boxX, boxY);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ValueXIsNullAndValueYIsNotNull_ExpectFalse()
        {
            var boxX = new Box<RefType>(null!);

            var y = new RefType
            {
                Id = 11
            };
            var boxY = new Box<RefType>(y);

            var actual = BoxSamenessComparer<RefType>.Default.Equals(boxX, boxY);
            Assert.False(actual);
        }

        [Test]
        public void Equals_ValueXIsNotNullAndValueYIsNull_ExpectFalse()
        {
            var x = new RefType
            {
                Id = 5
            };

            var boxX = new Box<RefType?>(x);
            var boxY = new Box<RefType?>(null);

            var actual = BoxSamenessComparer<RefType?>.Default.Equals(boxX, boxY);
            Assert.False(actual);
        }
    }
}
