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
        public void Same_OtherIsNotNull_ExpectFalse()
        {
            Box<int?>? box = new Box<int?>(null);
            Box<int?>? other = null;

            var actual = box.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_OtherIsSame_ExpectTrue()
        {
            var value = new StructType
            {
                Text = GenerateText()
            };
            var source = new Box<StructType>(value);
            var other = source;

            var actual = source.Same(other);
            Assert.True(actual);
        }

        [Test]
        public void Same_SourceValueSameOtherValue_ExpectFalse()
        {
            var text = GenerateText();

            var sorceValue = new StructType
            {
                Text = text
            };
            var source = new Box<StructType>(sorceValue);

            var otherValue = new StructType
            {
                Text = text
            };
            var other = new Box<StructType>(otherValue);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceValueIsNotEqualOtherValue_ExpectFalse()
        {
            var id = GenerateInteger();

            var sorceValue = new RefType
            {
                Id = id
            };
            var source = new Box<RefType>(sorceValue);

            var otherValue = new RefType
            {
                Id = id
            };
            var other = new Box<RefType>(otherValue);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceValueAndOtherValueAreNull_ExpectFalse()
        {
            var source = new Box<StubType?>(null);
            var other = new Box<StubType?>(null);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceValueIsNullAndOtherValueIsNotNull_ExpectFalse()
        {
            var source = new Box<RefType>(null!);

            var otherValue = new RefType
            {
                Id = GenerateInteger()
            };
            var other = new Box<RefType>(otherValue);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceValueIsNotNullAndOtherValueIsNull_ExpectFalse()
        {
            var sorceValue = new RefType
            {
                Id = GenerateInteger()
            };

            var source = new Box<RefType?>(sorceValue);
            var other = new Box<RefType?>(null);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_AIsNullAndBIsNull_ExpectTrue()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = null;

            var actual = Box<RefType>.Same(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void SameStaticOfT_AIsNullAndBIsNotNull_ExpectFalse()
        {
            Box<int?>? boxA = new Box<int?>(null);
            Box<int?>? boxB = null;

            var actual = Box<int?>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_AIsNotNullAndBIsNull_ExpectFalse()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = new Box<RefType>(new RefType());

            var actual = Box<RefType>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_AIsSameAsB_ExpectTrue()
        {
            var value = new StructType
            {
                Text = GenerateText()
            };
            var source = new Box<StructType>(value);

            var actual = Box<StructType>.Same(source, source);
            Assert.True(actual);
        }

        [Test]
        public void SameStaticOfT_ValueASameValueB_ExpectFalse()
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

            var actual = Box<StructType>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_ValueAIsNotEqualValueB_ExpectFalse()
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

            var actual = Box<RefType>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_ValueAAndValueBAreNull_ExpectFalse()
        {
            var boxA = new Box<StubType?>(null);
            var boxB = new Box<StubType?>(null);

            var actual = Box<StubType?>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_ValueAIsNullAndValueBIsNotNull_ExpectFalse()
        {
            var boxA = new Box<RefType>(null!);

            var b = new RefType
            {
                Id = GenerateInteger()
            };
            var boxB = new Box<RefType>(b);

            var actual = Box<RefType>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStaticOfT_ValueAIsNotNullAndValueBIsNull_ExpectFalse()
        {
            var a = new RefType
            {
                Id = GenerateInteger()
            };

            var boxA = new Box<RefType?>(a);
            var boxB = new Box<RefType?>(null);

            var actual = Box<RefType?>.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_AIsNullAndBIsNull_ExpectTrue()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = null;

            var actual = Box.Same(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void SameStatic_AIsNullAndBIsNotNull_ExpectFalse()
        {
            Box<int?>? boxA = new Box<int?>(null);
            Box<int?>? boxB = null;

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_AIsNotNullAndBIsNull_ExpectFalse()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = new Box<RefType>(new RefType());

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_AIsSameAsB_ExpectTrue()
        {
            var value = new StructType
            {
                Text = GenerateText()
            };
            var source = new Box<StructType>(value);

            var actual = Box.Same(source, source);
            Assert.True(actual);
        }

        [Test]
        public void SameStatic_ValueASameValueB_ExpectFalse()
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

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_ValueAIsNotEqualValueB_ExpectFalse()
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

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_ValueAAndValueBAreNull_ExpectFalse()
        {
            var boxA = new Box<StubType?>(null);
            var boxB = new Box<StubType?>(null);

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_ValueAIsNullAndValueBIsNotNull_ExpectFalse()
        {
            var boxA = new Box<RefType>(null!);

            var b = new RefType
            {
                Id = GenerateInteger()
            };
            var boxB = new Box<RefType>(b);

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_ValueAIsNotNullAndValueBIsNull_ExpectFalse()
        {
            var a = new RefType
            {
                Id = GenerateInteger()
            };

            var boxA = new Box<RefType?>(a);
            var boxB = new Box<RefType?>(null);

            var actual = Box.Same(boxA, boxB);
            Assert.False(actual);
        }
    }
}
