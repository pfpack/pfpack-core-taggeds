#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Infrastructure.Tests.Stubs;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxTests
    {
        [Test]
        public void Equals_OtherIsNotNull_ExpectFalse()
        {
            Box<int?>? box = new Box<int?>(null);
            Box<int?>? other = null;

            {
                var actual = box.Equals(other);
                Assert.False(actual);
            }

            {
                var actual = box.Equals((object)other);
                Assert.False(actual);
            }
        }

        [Test]
        public void Equals_OtherIsSame_ExpectTrue()
        {
            var value = SomeTextStructType;
            var source = new Box<StructType>(value);
            var other = source;

            {
                var actual = source.Equals(other);
                Assert.True(actual);
            }

            {
                var actual = source.Equals((object)other);
                Assert.True(actual);
            }
        }

        [Test]
        public void Equals_SourceValueEqualsOtherValue_ExpectTrue()
        {
            var text = SomeString;

            var sourceValue = new StructType
            {
                Text = text
            };
            var source = new Box<StructType>(sourceValue);

            var otherValue = new StructType
            {
                Text = text
            };
            var other = new Box<StructType>(otherValue);

            {
                var actual = source.Equals(other);
                Assert.True(actual);
            }

            {
                var actual = source.Equals((object)other);
                Assert.True(actual);
            }
        }

        [Test]
        public void Equals_SourceValueIsNotEqualOtherValue_ExpectFalse()
        {
            var id = MinusFifteen;

            var sourceValue = new RefType
            {
                Id = id
            };
            var source = new Box<RefType>(sourceValue);

            var otherValue = new RefType
            {
                Id = id
            };
            var other = new Box<RefType>(otherValue);

            {
                var actual = source.Equals(other);
                Assert.False(actual);
            }

            {
                var actual = source.Equals((object)other);
                Assert.False(actual);
            }
        }

        [Test]
        public void Equals_SourceValueAndOtherValueAreNull_ExpectTrue()
        {
            var source = new Box<StubType?>(null);
            var other = new Box<StubType?>(null);

            {
                var actual = source.Equals(other);
                Assert.True(actual);
            }

            {
                var actual = source.Equals((object)other);
                Assert.True(actual);
            }
        }

        [Test]
        public void Equals_SourceValueIsNullAndOtherValueIsNotNull_ExpectFalse()
        {
            var source = new Box<RefType>(null!);

            var otherValue = PlusFifteenIdRefType;
            var other = new Box<RefType>(otherValue);

            {
                var actual = source.Equals(other);
                Assert.False(actual);
            }

            {
                var actual = source.Equals((object)other);
                Assert.False(actual);
            }
        }

        [Test]
        public void Equals_SourceValueIsNotNullAndOtherValueIsNull_ExpectFalse()
        {
            var sourceValue = PlusFifteenIdRefType;

            var source = new Box<RefType?>(sourceValue);
            var other = new Box<RefType?>(null);

            {
                var actual = source.Equals(other);
                Assert.False(actual);
            }

            {
                var actual = source.Equals((object)other);
                Assert.False(actual);
            }
        }

        [Test]
        public void EqualsStaticOfT_AIsNullAndBIsNull_ExpectTrue()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = null;

            var actual = Box<RefType>.Equals(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStaticOfT_AIsNullAndBIsNotNull_ExpectFalse()
        {
            Box<int?>? boxA = new Box<int?>(null);
            Box<int?>? boxB = null;

            var actual = Box<int?>.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStaticOfT_AIsNotNullAndBIsNull_ExpectFalse()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = new Box<RefType>(MinusFifteenIdRefType);

            var actual = Box<RefType>.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStaticOfT_AIsSameAsB_ExpectTrue()
        {
            var value = SomeTextStructType;
            var source = new Box<StructType>(value);

            var actual = Box<StructType>.Equals(source, source);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStaticOfT_ValueAEqualsValueB_ExpectTrue()
        {
            var text = SomeString;

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

            var actual = Box<StructType>.Equals(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStaticOfT_ValueAIsNotEqualValueB_ExpectFalse()
        {
            var id = int.MinValue;

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

            var actual = Box<RefType>.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStaticOfT_ValueAAndValueBAreNull_ExpectTrue()
        {
            var boxA = new Box<StubType?>(null);
            var boxB = new Box<StubType?>(null);

            var actual = Box<StubType?>.Equals(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStaticOfT_ValueAIsNullAndValueBIsNotNull_ExpectFalse()
        {
            var boxA = new Box<RefType>(null!);

            var b = PlusFifteenIdRefType;
            var boxB = new Box<RefType>(b);

            var actual = Box<RefType>.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStaticOfT_ValueAIsNotNullAndValueBIsNull_ExpectFalse()
        {
            var a = PlusFifteenIdRefType;

            var boxA = new Box<RefType?>(a);
            var boxB = new Box<RefType?>(null);

            var actual = Box<RefType?>.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_AIsNullAndBIsNull_ExpectTrue()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = null;

            var actual = Box.Equals(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_AIsNullAndBIsNotNull_ExpectFalse()
        {
            Box<int?>? boxA = new Box<int?>(null);
            Box<int?>? boxB = null;

            var actual = Box.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_AIsNotNullAndBIsNull_ExpectFalse()
        {
            Box<RefType>? boxA = null;
            Box<RefType>? boxB = new Box<RefType>(MinusFifteenIdRefType);

            var actual = Box.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_AIsSameAsB_ExpectTrue()
        {
            var value = SomeTextStructType;
            var source = new Box<StructType>(value);

            var actual = Box.Equals(source, source);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_ValueAEqualsValueB_ExpectTrue()
        {
            var text = SomeString;

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

            var actual = Box.Equals(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_ValueAIsNotEqualValueB_ExpectFalse()
        {
            var id = PlusFifteen;

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

            var actual = Box.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_ValueAAndValueBAreNull_ExpectTrue()
        {
            var boxA = new Box<StubType?>(null);
            var boxB = new Box<StubType?>(null);

            var actual = Box.Equals(boxA, boxB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_ValueAIsNullAndValueBIsNotNull_ExpectFalse()
        {
            var boxA = new Box<RefType>(null!);

            var b = MinusFifteenIdRefType;
            var boxB = new Box<RefType>(b);

            var actual = Box.Equals(boxA, boxB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_ValueAIsNotNullAndValueBIsNull_ExpectFalse()
        {
            var a = PlusFifteenIdRefType;

            var boxA = new Box<RefType?>(a);
            var boxB = new Box<RefType?>(null);

            var actual = Box.Equals(boxA, boxB);
            Assert.False(actual);
        }
    }
}
