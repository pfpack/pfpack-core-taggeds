#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Infrastructure.Tests.Stubs;
using System;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxEqualityComparerTests
    {
        [Test]
        public void GetHashCode_BoxIsNull_ExpectArgumentNullException()
        {
            Box<RefType> box = null!;
            var comparer = new BoxEqualityComparer<RefType>();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = comparer.GetHashCode(box));
            Assert.AreEqual("box", ex.ParamName);
        }

        [Test]
        public void GetHashCode_BoxValueIsNull_ExpectResultIsBoxHashCode()
        {
            var box = new Box<RefType?>(null);
            var comparer = new BoxEqualityComparer<RefType?>();

            var actual = comparer.GetHashCode(box);
            var expected = box.GetHashCode();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetHashCode_BoxValueIsNtNull_ExpectResultIsBoxHashCode()
        {
            var box = new Box<StructType>(new StructType());
            var comparer = new BoxEqualityComparer<StructType>();

            var actual = comparer.GetHashCode(box);
            var expected = box.GetHashCode();

            Assert.AreEqual(actual, expected);
        }
    }
}
