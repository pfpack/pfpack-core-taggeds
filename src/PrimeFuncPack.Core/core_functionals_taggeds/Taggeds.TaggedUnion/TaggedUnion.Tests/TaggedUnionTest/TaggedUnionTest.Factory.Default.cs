#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void Default_ExpectIsFirstGetsFalse()
        {
            var taggedUnion = default(TaggedUnion<RefType?, StructType>);
            Assert.IsFalse(taggedUnion.IsFirst);
        }

        [Test]
        public void Default_ExpectIsSecondGetsFalse()
        {
            var taggedUnion = default(TaggedUnion<StructType?, RefType>);
            Assert.IsFalse(taggedUnion.IsSecond);
        }

        [Test]
        public void Default_ExpectIsInitializedGetsFalse()
        {
            var taggedUnion = default(TaggedUnion<RefType?, StructType?>);
            Assert.IsFalse(taggedUnion.IsInitialized);
        }
    }
}
