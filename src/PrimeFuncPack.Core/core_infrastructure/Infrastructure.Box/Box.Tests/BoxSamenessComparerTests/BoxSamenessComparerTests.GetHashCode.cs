#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxSamenessComparerTests
    {
        [Test]
        public void GetHashCode_BoxIsNull_ExpectArgumentNullException()
        {
            Box<RefType> box = null!;
            var comparer = new BoxSamenessComparer<RefType>();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = comparer.GetHashCode(box));
            Assert.AreEqual("box", ex.ParamName);
        }

        [Test]
        public void GetHashCode_BoxValueIsNull_ExpectResultIsBoxSamenessHashCode()
        {
            var box = new Box<RefType?>(null);
            var comparer = new BoxSamenessComparer<RefType?>();

            var actual = comparer.GetHashCode(box);
            var expected = box.GetSamenessHashCode();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetHashCode_BoxValueIsNtNull_ExpectResultIsBoxSamenessHashCode()
        {
            var box = new Box<StructType>(SomeTextStructType);
            var comparer = new BoxSamenessComparer<StructType>();

            var actual = comparer.GetHashCode(box);
            var expected = box.GetSamenessHashCode();

            Assert.AreEqual(actual, expected);
        }
    }
}
