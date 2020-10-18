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
        public void Equals_NonGeneric_OtherIsNotBox_ExpectFalse()
        {
            // Box<RefType>(PlusFifteenIdRefType)

            {
                var box = new Box<RefType>(PlusFifteenIdRefType);
                var actual = box.Equals((object?)null);
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<RefType>(PlusFifteenIdRefType);
                var actual = box.Equals(new object());
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<RefType>(PlusFifteenIdRefType);
                var actual = box.Equals((object)PlusFifteenIdRefType);
                Assert.IsFalse(actual);
            }

            // Box<RefType?>(MinusFifteenIdRefType)

            {
                var box = new Box<RefType?>(MinusFifteenIdRefType);
                var actual = box.Equals((object?)null);
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<RefType?>(MinusFifteenIdRefType);
                var actual = box.Equals(new object());
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<RefType?>(MinusFifteenIdRefType);
                var actual = box.Equals((object)MinusFifteenIdRefType);
                Assert.IsFalse(actual);
            }

            // Box<StructType>(SomeTextStructType)

            {
                var box = new Box<StructType>(SomeTextStructType);
                var actual = box.Equals((object?)null);
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<StructType>(SomeTextStructType);
                var actual = box.Equals(new object());
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<StructType>(SomeTextStructType);
                var actual = box.Equals((object)SomeTextStructType);
                Assert.IsFalse(actual);
            }

            // Box<StructType?>(SomeTextStructType)

            {
                var box = new Box<StructType?>(SomeTextStructType);
                var actual = box.Equals((object?)null);
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<StructType?>(SomeTextStructType);
                var actual = box.Equals(new object());
                Assert.IsFalse(actual);
            }

            {
                var box = new Box<StructType?>(SomeTextStructType);
                var actual = box.Equals((object)(StructType?)SomeTextStructType);
                Assert.IsFalse(actual);
            }
        }
    }
}
